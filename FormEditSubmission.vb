Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class FormEditSubmission
    Private ReadOnly _index As Integer
    Private ReadOnly _submission As Submission
    Private ReadOnly _baseUrl As String

    Public Sub New(index As Integer, submission As Submission, baseUrl As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        _index = index
        _submission = submission
        _baseUrl = baseUrl
    End Sub

    Private Sub FormEditSubmission_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load the submission data into the text fields
        txtEditName.Text = _submission.Name
        txtEditEmail.Text = _submission.Email
        txtEditPhone.Text = _submission.Phone
        txtEditGithubLink.Text = _submission.GithubLink
        txtEditStopwatchTime.Text = _submission.StopwatchTime
    End Sub

    Private Async Sub btnSubmitEdit_Click(sender As Object, e As EventArgs) Handles btnSubmitEdit.Click
        Try
            Dim client As New HttpClient()
            Dim submissionData = New With {
                .name = txtEditName.Text,
                .email = txtEditEmail.Text,
                .phone = txtEditPhone.Text,
                .github_link = txtEditGithubLink.Text,
                .stopwatch_time = txtEditStopwatchTime.Text
            }

            ' Serialize the submission data to JSON
            Dim jsonContent = JsonConvert.SerializeObject(submissionData)
            Dim content As New StringContent(jsonContent, Encoding.UTF8, "application/json")

            ' Log the JSON content for debugging
            Console.WriteLine("Sending JSON: " & jsonContent)

            Dim response = Await client.PutAsync($"{_baseUrl}/edit?index={_index}", content)

            ' Log the response status for debugging
            Console.WriteLine("Response Status: " & response.StatusCode)

            Dim responseContent = Await response.Content.ReadAsStringAsync()
            Console.WriteLine("Response Content: " & responseContent)

            If response.IsSuccessStatusCode Then
                MessageBox.Show("Submission edited successfully")
                Me.Close() ' Close the edit form on success
            Else
                MessageBox.Show("Error editing submission: " & response.ReasonPhrase & Environment.NewLine & responseContent)
            End If
        Catch ex As HttpRequestException
            MessageBox.Show("Failed to edit submission. Please check if the server is running.")
        Catch ex As Exception
            MessageBox.Show($"An unexpected error occurred: {ex.Message}")
        End Try
    End Sub
End Class
