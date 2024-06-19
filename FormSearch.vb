Imports Newtonsoft.Json
Imports System.Net.Http

Public Class FormSearch
    Private Const BaseUrl As String = "http://localhost:3000"
    Private Async Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim email As String = txtEmail.Text
        Dim results As List(Of Submission) = Await SearchSubmissionByEmail(email)
        If results IsNot Nothing AndAlso results.Count > 0 Then
            dgvResults.DataSource = results
        Else
            MessageBox.Show("No submissions found for the given email.")
        End If
    End Sub

    Private Async Function SearchSubmissionByEmail(email As String) As Task(Of List(Of Submission))
        Dim client As New HttpClient()
        Dim response As HttpResponseMessage = Await client.GetAsync($"{BaseUrl}/search?email={email}")
        If response.IsSuccessStatusCode Then
            Dim content As String = Await response.Content.ReadAsStringAsync()
            Return JsonConvert.DeserializeObject(Of List(Of Submission))(content)
        Else
            MessageBox.Show("Error searching submissions")
            Return Nothing
        End If
    End Function
End Class
