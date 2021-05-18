Imports System.Drawing
Imports System.IO
Imports System.Web.UI.WebControls

Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Εκκίνηση
        Button1.Visible = False
        ReadFile("")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Go to next question
        If Button1.Visible Then
            MsgBox("Για να ξεκινήσεις πάτα το κουμπί Εκκίνηση")
        Else
            ReadFile("next")
        End If

    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Go to previous question
        If Button1.Visible Then
            MsgBox("Για να ξεκινήσεις πάτα το κουμπί Εκκίνηση")
        Else
            ReadFile("prev")
        End If

    End Sub

    Function ReadFile(action As String)
        Dim last As Integer = File.ReadAllLines("C:\Users\" + Environment.UserName + "\source\repos\Questionnaire\Questionnaire\TextFile1.txt").Length()
        If IsPostBack <> 0 Then 'Timer

            Session("Timer") = 20
            timeLabel.Text = Session("Timer")
            timeLabel.ForeColor = Color.Green
            Timer1.Enabled = True
        End If
        If action = "next" And Session("arithm") < last - 1 Then 'go to Next question
            Session("arithm") += 1
        ElseIf action = "prev" And Session("arithm") > 0 Then 'go to Previous queestion
            Session("arithm") -= 1
            End If
        number.Text = Session("arithm") + 1 'number of question
        Dim Counter As String = System.IO.File.ReadAllLines("C:\Users\" + Environment.UserName + "\source\repos\Questionnaire\Questionnaire\TextFile1.txt")(Session("arithm"))
        TextBox1.Text = Between(Counter, "p|", "\1") ' Question
        Choices(Counter)
        Return 0
    End Function
    Function Choices(count As String)

        If count.Contains("yn") Then
            RadioButtonList1.Items.Clear()
            BulletedList1.Items.Clear()
            Dim image1 As String = Between(count, "n|", ", ")
            Dim image2 As String = Between(count, ", ", "|")
            Dim lab1 As String = Between(count, "1. ", "\2")
            Dim lab2 As String = Between(count, "\2. ", "")
            Label1.Text = lab1
            Label2.Text = lab2
            test1.ImageUrl = image1
            test1.AlternateText = lab1
            test2.ImageUrl = image2
            test2.AlternateText = lab2
        End If

        If count.Contains("1..2") Then
            RadioButtonList1.Items.Clear()
            BulletedList1.Items.Clear()
            Dim image_1 As String = Between(count, ".2|", ", ")
            Dim image_2 As String = Between(count, ", ", "|")
            Dim lb1 As String = Between(count, "1. ", "\2")
            Dim lb2 As String = Between(count, "\2. ", "")
            Label1.Text = lb1
            Label2.Text = lb2
            test1.ImageUrl = image_1
            test1.AlternateText = lb1
            test2.ImageUrl = image_2
            test2.AlternateText = lb2
        End If
        If count.Contains("bullet") Then
            RadioButtonList1.Items.Clear()
            BulletedList1.Items.Clear()
            Dim img As String = Between(count, "t|", "|")
            Dim bullet As String = Between(count, ". ", "\")
            Dim i As Integer = 1
            Dim first As String
            Dim last As String
            While i < 4
                first = "\" & i & "."
                last = "\" & i + 1 & "."
                bullet = Between(count, first, last)
                RadioButtonList1.Items.Add(New ListItem(bullet))
                i += 1
            End While
            bullet = Between(count, last, " ")
            RadioButtonList1.Items.Add(New ListItem(bullet))
            test1.ImageUrl = img
            test2.ImageUrl = Nothing
            test1.AlternateText = Nothing
            test2.AlternateText = Nothing
            Label1.Text = Nothing
            Label2.Text = Nothing

        End If
        If count.Contains("bulletn") Then
            RadioButtonList1.Items.Clear()
            BulletedList1.Items.Clear()
            Dim img As String = Between(count, "n|", "|")
            Dim bulletn As String = Between(count, ". ", "\")
            Dim i As Integer = 1
            Dim first As String
            Dim last As String
            While i < 3
                first = "\" & i & "."
                last = "\" & i + 1 & "."
                bulletn = Between(count, first, last)
                BulletedList1.Items.Add(New ListItem(bulletn))
                i += 1
            End While
            bulletn = Between(count, last, " ")
            BulletedList1.Items.Add(New ListItem(bulletn))
            test1.ImageUrl = img
            test2.ImageUrl = Nothing
            test1.AlternateText = Nothing
            test2.AlternateText = Nothing
            Label1.Text = Nothing
            Label2.Text = Nothing
        End If

        Return 0
    End Function

    Function Between(value As String, a As String,
                     b As String) As String
        ' Get positions for both string arguments.
        Dim posA As Integer = value.IndexOf(a)
        Dim posB As Integer = value.LastIndexOf(b)
        If posA = -1 Then
            Return ""
        End If
        If posB = -1 Then
            Return ""
        End If

        Dim adjustedPosA As Integer = posA + a.Length
        If adjustedPosA >= posB Then
            Return ""
        End If

        ' Get the substring between the two positions.
        Return value.Substring(adjustedPosA, posB - adjustedPosA)
    End Function

    Protected Sub ImageButton_Click(sender As Object, e As ImageClickEventArgs) Handles test2.Click, test1.Click
        Dim b As ImageButton = CType(sender, ImageButton)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\" + Environment.UserName + "\source\repos\Questionnaire\Questionnaire\test.txt", True)
        file.WriteLine(Session("arithm") + 1 & ". " & b.AlternateText)
        file.Close()
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\" + Environment.UserName + "\source\repos\Questionnaire\Questionnaire\test.txt", True)
        file.WriteLine(Session("arithm") + 1 & "." & RadioButtonList1.Text)
        file.Close()
    End Sub

    Protected Sub BulletedList1_Click(sender As Object, e As BulletedListEventArgs) Handles BulletedList1.Click

        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\" + Environment.UserName + "\source\repos\Questionnaire\Questionnaire\test.txt", True)
        file.WriteLine(Session("arithm") + 1 & "." & BulletedList1.DataSource)
        file.Close()
    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Button1.Visible = False Then
            If timeLabel.Text = "10" Then 'in the last 10 seconds (red)warning to be quicker in his answer
                timeLabel.ForeColor = Color.Red
                timeLabel.Text = Val(timeLabel.Text) - 1
            ElseIf timeLabel.Text = "0" Then
                Timer1.Enabled = False
                MsgBox("Times Up")

                Button3_Click(Nothing, Nothing) 'click to go to next question
                Response.Redirect(Request.Url.AbsoluteUri) 'reload page

            Else
                timeLabel.Text = Val(timeLabel.Text) - 1
            End If
        End If

    End Sub
End Class