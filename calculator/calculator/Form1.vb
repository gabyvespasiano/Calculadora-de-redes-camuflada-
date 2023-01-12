Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        mascara(TextBox1.Text)

    End Sub
    Private Sub mascara(masc As String)
        TextBox2.Text = ""
        Dim i As Integer
        Dim s As String
        If masc.Contains(".") Then
            For j = 0 To Split(masc, ".").Count - 1
                i = Split(masc, ".")(j)
                s = Convert.ToString(i, 2).PadLeft(8, "0"c) '32 bits
                If j = Split(masc, ".").Count - 1 Then
                    TextBox2.Text += s

                Else
                    TextBox2.Text += s & "."

                End If

            Next


        Else
            i = Int(masc)
            s = Convert.ToString(i, 2).PadLeft(8, "0"c) '32 bits
            TextBox2.Text = s
        End If


        Label1.Text = Split(TextBox2.Text, "1").Count - 1 'es el texto que va en /  ejemplo 192.168.1.0 /24  255.255.255.0
        Dim h As String
        For k = 0 To Split(TextBox2.Text, "0").Count - 2
            h += "1"
        Next

        Label2.Text = Convert.ToInt32(h, 2) - 1.ToString
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Label4.Text = TextBox2.Text 'mascara en binario
    End Sub
    Dim arr As New ArrayList
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        arr.Add("255.255.255.255")
        arr.Add("255.255.255.254")
        arr.Add("255.255.255.252")
        arr.Add("255.255.255.248")
        arr.Add("255.255.255.240")
        arr.Add("255.255.255.224")
        arr.Add("255.255.255.192")
        arr.Add("255.255.255.128")
        arr.Add("255.255.255.0")

        arr.Add("255.255.254.0")
        arr.Add("255.255.252.0")
        arr.Add("255.255.248.0")
        arr.Add("255.255.240.0")
        arr.Add("255.255.224.0")
        arr.Add("255.255.192.0")
        arr.Add("255.255.128.0")

        arr.Add("255.255.0.0")
        arr.Add("255.254.0.0")
        arr.Add("255.252.0.0")
        arr.Add("255.248.0.0")
        arr.Add("255.240.0.0")
        arr.Add("255.224.0.0")
        arr.Add("255.192.0.0")
        arr.Add("255.128.0.0")

        arr.Add("255.0.0.0")
        arr.Add("254.0.0.0")
        arr.Add("252.0.0.0")
        arr.Add("248.0.0.0")
        arr.Add("240.0.0.0")
        arr.Add("224.0.0.0")
        arr.Add("192.0.0.0")
        arr.Add("128.0.0.0")
        TextBox1.Text = "123"
        TextBox1.Text = ""
    End Sub
    Private Sub con()
        TextBox3.Text = ""
        If TextBox2.Text.Contains(".") Then
            For j = 0 To Split(TextBox2.Text, ".").Count - 1

                If j = Split(TextBox2.Text, ".").Count - 1 Then
                    TextBox3.Text += Convert.ToInt32(Split(TextBox2.Text, ".")(j), 2).ToString

                Else
                    TextBox3.Text += Convert.ToInt32(Split(TextBox2.Text, ".")(j), 2).ToString & "."

                End If

            Next


        Else
            TextBox3.Text += Convert.ToInt32(TextBox2.Text, 2).ToString
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        con()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text.Count = 0 Then
        Else

            Dim h As String
            For k = 0 To Split(TextBox2.Text, "0").Count - 2
                h += "1"
            Next


            Label2.Text = Convert.ToInt32(h, 2) - 1.ToString ' cantidad de host que soporta esa red en total
            Label2.Text = "0"
            For i = 0 To arr.Count - 1
                If Int(Label2.Text) > Int(TextBox1.Text) Then
                    Label6.Text = i - 1
                    Exit For
                Else
                    mascara(arr(i))
                End If
            Next
            con()
            salto()
        End If

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        TextBox1.Focus()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Label3.Text = TextBox1.Text
    End Sub
    Dim loc = 374
    Dim tam = 10
    Dim primera As Boolean = True
    Dim ant As Integer
    Dim after As Boolean
    Private Sub Label3_TextChanged(sender As Object, e As EventArgs) Handles Label3.TextChanged
        If primera Then
            primera = False
        Else
            If Label3.Text.Count > ant Then
                Dim pp As Integer

                If after Then
                    pp = Label3.Location.X - tam - 10
                    after = False
                Else
                    pp = Label3.Location.X - tam
                End If
                Dim p As New Point(pp, 48)
                Label3.Location = p
                ant = Label3.Text.Count
            ElseIf Label3.Text.Count = 0 Then
                Label3.Text = "0"
                Dim p As New Point((loc), 48)
                Label3.Location = p
                after = True
            Else
                Dim p As New Point((Label3.Location.X + tam), 48)
                Label3.Location = p
                ant = Label3.Text.Count
            End If
        End If
    End Sub

    Private Sub salto()
        'TextBox2.Text
        Dim last As String
        For i = 0 To Split(TextBox2.Text, ".").Count - 1
            If Split(TextBox2.Text, ".")(i).Contains("1") Then
                last = Split(TextBox2.Text, ".")(i)
            End If
        Next
        Label7.Text = ((256 - Convert.ToInt32(last, 2)).ToString) ' para calcular el salto
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Label5.Text = TextBox3.Text 'mascara en decimal
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        Label1.Text = "0"
        Label2.Text = "0"
        Label3.Text = "0"
        Label4.Text = "0"
        Label5.Text = "0"
        Label6.Text = "0"
        Label7.Text = "0"
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        TextBox2.Focus()

    End Sub
End Class
