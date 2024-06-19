Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class Submission
    <JsonProperty("name")>
    Public Property Name As String
    <JsonProperty("email")>
    Public Property Email As String
    <JsonProperty("phone")>
    Public Property Phone As String
    <JsonProperty("github_link")>
    Public Property GithubLink As String
    <JsonProperty("stopwatch_time")>
    Public Property StopwatchTime As String
End Class

Public Class FormViewSubmissions
    Public Const BaseUrl As String = "http://localhost:3000"
    Private submissions As List(Of Submission)
    Private currentIndex As Integer

    Private Async Sub FormViewSubmissions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        currentIndex = 0
        Await LoadAndDisplaySubmission(currentIndex)
    End Sub

    Private Sub FormViewSubmissions_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.P Then
            btnPrevious.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            btnNext.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.D Then
            btnDelete.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.E Then
            btnEdit.PerformClick()
        End If
    End Sub

    Private Async Function LoadAndDisplaySubmission(index As Integer) As Task
        Dim submission As Submission = Await LoadSubmissions(index)
        If submission IsNot Nothing Then
            DisplaySubmission(submission)
        Else
            Console.WriteLine("No submission found at index " & index)
        End If
    End Function

    Private Async Function LoadSubmissions(index As Integer) As Task(Of Submission)
        Try
            Dim client As New HttpClient()
            Dim response = Await client.GetAsync($"{BaseUrl}/read?index={index}")

            ' Log the response status for debugging
            Console.WriteLine("Response Status: " & response.StatusCode)

            Dim responseContent = Await response.Content.ReadAsStringAsync()
            Console.WriteLine("Response Content: " & responseContent)

            ' Check if the response content is a valid JSON
            If Not String.IsNullOrWhiteSpace(responseContent) Then
                Try
                    Dim submission = JsonConvert.DeserializeObject(Of Submission)(responseContent)
                    Console.WriteLine("Parsed Submission: " & JsonConvert.SerializeObject(submission))
                    Return submission
                Catch jsonEx As JsonException
                    MessageBox.Show($"JSON Deserialization error: {jsonEx.Message}")
                    Console.WriteLine("JSON Deserialization error: " & jsonEx.Message)
                    Return Nothing
                End Try
            Else
                MessageBox.Show("Server returned empty response.")
                Return Nothing
            End If
        Catch ex As HttpRequestException
            MessageBox.Show("Failed to load submission. Please check if the server is running.")
            Return Nothing
        Catch ex As Exception
            MessageBox.Show($"An unexpected error occurred: {ex.Message}")
            Return Nothing
        End Try
    End Function

    Private Sub DisplaySubmission(submission As Submission)
        txtName.Text = submission.Name
        txtEmail.Text = submission.Email
        txtPhone.Text = submission.Phone
        txtGithubLink.Text = submission.GithubLink
        lblStopwatchTime.Text = submission.StopwatchTime

        ' Log the displayed values for debugging
        Console.WriteLine("Displayed Name: " & txtName.Text)
        Console.WriteLine("Displayed Email: " & txtEmail.Text)
        Console.WriteLine("Displayed Phone: " & txtPhone.Text)
        Console.WriteLine("Displayed Github Link: " & txtGithubLink.Text)
        Console.WriteLine("Displayed Stopwatch Time: " & lblStopwatchTime.Text)
    End Sub

    Private Async Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            Await LoadAndDisplaySubmission(currentIndex)
        End If
    End Sub

    Private Async Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        currentIndex += 1
        Await LoadAndDisplaySubmission(currentIndex)
    End Sub

    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Await DeleteSubmission(currentIndex)
        ' Reload and display the first submission after deletion
        Await LoadAndDisplaySubmission(0)
    End Sub

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim submission As Submission = Await LoadSubmissions(currentIndex)
        If submission IsNot Nothing Then
            Dim editForm As New FormEditSubmission(currentIndex, submission, BaseUrl)
            editForm.ShowDialog()
            Await LoadAndDisplaySubmission(currentIndex)
        Else
            MessageBox.Show("No submission found to edit.")
        End If
    End Sub


    Private Async Function DeleteSubmission(index As Integer) As Task
        Try
            Dim client As New HttpClient()
            Dim response = Await client.DeleteAsync($"{BaseUrl}/delete?index={index}")

            ' Log the response status for debugging
            Console.WriteLine("Response Status: " & response.StatusCode)

            Dim responseContent = Await response.Content.ReadAsStringAsync()
            Console.WriteLine("Response Content: " & responseContent)

            If response.IsSuccessStatusCode Then
                MessageBox.Show("Submission deleted successfully")
            Else
                MessageBox.Show("Error deleting submission: " & response.ReasonPhrase & Environment.NewLine & responseContent)
            End If
        Catch ex As HttpRequestException
            MessageBox.Show("Failed to delete submission. Please check if the server is running.")
        Catch ex As Exception
            MessageBox.Show($"An unexpected error occurred: {ex.Message}")
        End Try
    End Function

    Private Async Function EditSubmission(index As Integer) As Task
        Try
            Dim client As New HttpClient()
            Dim submissionData = New With {
                .name = txtName.Text,
                .email = txtEmail.Text,
                .phone = txtPhone.Text,
                .github_link = txtGithubLink.Text,
                .stopwatch_time = lblStopwatchTime.Text
            }

            ' Serialize the submission data to JSON
            Dim jsonContent = JsonConvert.SerializeObject(submissionData)
            Dim content As New StringContent(jsonContent, Encoding.UTF8, "application/json")

            ' Log the JSON content for debugging
            Console.WriteLine("Sending JSON: " & jsonContent)

            Dim response = Await client.PutAsync($"{BaseUrl}/edit?index={index}", content)

            ' Log the response status for debugging
            Console.WriteLine("Response Status: " & response.StatusCode)

            Dim responseContent = Await response.Content.ReadAsStringAsync()
            Console.WriteLine("Response Content: " & responseContent)

            If response.IsSuccessStatusCode Then
                MessageBox.Show("Submission edited successfully")
            Else
                MessageBox.Show("Error editing submission: " & response.ReasonPhrase & Environment.NewLine & responseContent)
            End If
        Catch ex As HttpRequestException
            MessageBox.Show("Failed to edit submission. Please check if the server is running.")
        Catch ex As Exception
            MessageBox.Show($"An unexpected error occurred: {ex.Message}")
        End Try
    End Function
End Class
