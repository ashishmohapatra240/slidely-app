Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class FormCreateSubmission
    Private stopwatch As New Stopwatch()
    Private WithEvents timer As New Timer()

    Private Sub FormCreateSubmission_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        timer.Interval = 1000
    End Sub

    Private Sub FormCreateSubmission_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.T Then
            btnToggleStopwatch.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            btnSubmit.PerformClick()
        End If
    End Sub

    Private Sub btnToggleStopwatch_Click(sender As Object, e As EventArgs) Handles btnToggleStopwatch.Click
        If stopwatch.IsRunning Then
            stopwatch.Stop()
            timer.Stop()
        Else
            stopwatch.Start()
            timer.Start()
        End If
    End Sub

    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        lblStopwatchTime.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
    End Sub

    Private Async Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
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

            Dim response = Await client.PostAsync("http://localhost:3000/submit", content)

            ' Log the response status for debugging
            Console.WriteLine("Response Status: " & response.StatusCode)

            Dim responseContent = Await response.Content.ReadAsStringAsync()
            Console.WriteLine("Response Content: " & responseContent)

            If response.IsSuccessStatusCode Then
                MessageBox.Show("Submission successful")
            Else
                MessageBox.Show("Error in submission: " & response.ReasonPhrase & Environment.NewLine & responseContent)
            End If
        Catch ex As HttpRequestException
            MessageBox.Show("Failed to submit. Please check if the server is running.")
        Catch ex As Exception
            MessageBox.Show($"An unexpected error occurred: {ex.Message}")
        End Try
    End Sub
End Class
