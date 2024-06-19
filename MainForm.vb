Imports System.Net.Http

Public Class MainForm
    Private Const BaseUrl As String = "http://localhost:3000"

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            btnViewSubmissions.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            btnCreateSubmission.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.F Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnViewSubmissions_Click(sender As Object, e As EventArgs) Handles btnViewSubmissions.Click
        Dim viewForm As New FormViewSubmissions()
        viewForm.Show()
    End Sub

    Private Sub btnCreateSubmission_Click(sender As Object, e As EventArgs) Handles btnCreateSubmission.Click
        Dim createForm As New FormCreateSubmission()
        createForm.Show()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchForm As New FormSearch()
        searchForm.Show()
    End Sub

    Private Async Sub btnCheckServerStatus_Click(sender As Object, e As EventArgs) Handles btnCheckServerStatus.Click
        Try
            Dim client As New HttpClient()
            Dim response As HttpResponseMessage = Await client.GetAsync($"{BaseUrl}/ping")
            If response.IsSuccessStatusCode Then
                MessageBox.Show("Server is running.")
            Else
                MessageBox.Show("Server is not reachable.")
            End If
        Catch ex As HttpRequestException
            MessageBox.Show("Server is not reachable. Please check if the server is running.")
        Catch ex As Exception
            MessageBox.Show($"An unexpected error occurred: {ex.Message}")
        End Try
    End Sub

End Class
