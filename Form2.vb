Imports System.IO
Imports System.Net
Public Class Form2

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database4DataSet2.Table4' table. You can move, or remove it, as needed.
        Me.Table4TableAdapter1.Fill(Me.Database4DataSet2.Table4)
        'TODO: This line of code loads data into the 'Database1DataSet3.Table1' table. You can move, or remove it, as needed.
        Me.Table1TableAdapter1.Fill(Me.Database1DataSet3.Table1)
        'TODO: This line of code loads data into the 'Database4DataSet1.Table4' table. You can move, or remove it, as needed.
        Me.Table4TableAdapter.Fill(Me.Database4DataSet1.Table4)
        Timer2.Enabled = True
        'TODO: This line of code loads data into the 'Database3DataSet1.Table3' table. You can move, or remove it, as needed.
        Me.Table3TableAdapter.Fill(Me.Database3DataSet1.Table3)
        'TODO: This line of code loads data into the 'Database2DataSet1.Table2' table. You can move, or remove it, as needed.
        Me.Table2TableAdapter.Fill(Me.Database2DataSet1.Table2)
        'TODO: This line of code loads data into the 'Database1DataSet1.Table1' table. You can move, or remove it, as needed.
        Me.Table1TableAdapter.Fill(Me.Database1DataSet1.Table1)

        ' Fill the table adapter
        Me.Table1TableAdapter.Fill(Me.Database1DataSet1.Table1)

        ' Populate the ComboBox with location names
        ComboBox1.DataSource = Me.Database1DataSet1.Table1
        ComboBox1.DisplayMember = "Location"
        ComboBox1.ValueMember = "ID"  ' Optional: If you want to use the ID as the value member

        Dim orderItems As New System.Text.StringBuilder()

        ' Loop through each row in the DataTable
        For Each row As DataRow In Me.Database2DataSet1.Table2.Rows
            ' Check if the quantity is greater than or equal to 1
            Dim quantity As Integer = CInt(row("Quantity"))
            If quantity >= 1 Then
                ' Append the food item and its quantity to the orderItems StringBuilder
                orderItems.AppendLine(row("Food Item").ToString() & " - " & quantity.ToString() & " ")
            End If
        Next

        ' Update Label3.Text with the order items
        Label3.Text = orderItems.ToString()

        Dim colsum As Decimal = 0
        For Each R As DataGridViewRow In DataGridView2.Rows
            colsum += CDec(R.Cells(3).Value)
        Next
        Label21.Text = "RM" + colsum.ToString()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim fname, lname, address, district, payment, details, price, time, process As String
        Dim card As Integer
        Dim phone As Long

        fname = TextBox1.Text
        lname = TextBox2.Text
        address = TextBox3.Text

        ' Assuming ComboBox1 contains plain string items
        district = Label23.Text

        payment = ComboBox3.SelectedItem.ToString()
        card = CInt(TextBox4.Text)
        details = Label3.Text
        price = Label21.Text
        phone = TextBox5.Text
        process = "Processing"
        time = Date.Now.ToString("dd - MMM - yyyy HH : mm : ss")

        Me.Table4TableAdapter1.Insert(fname, lname, phone, address, district, payment, card, details, price, process, time)

        Me.Table4TableAdapter1.Update(Me.Database4DataSet2.Table4)
        Me.Table4TableAdapter1.Fill(Me.Database4DataSet2.Table4)

        'START FROM HERE
        Dim orderItems As New System.Text.StringBuilder()

        ' Loop through each row in the DataTable
        For Each row As DataRow In Me.Database2DataSet1.Table2.Rows
            ' Check if the quantity is greater than or equal to 1
            Dim quantity As Integer = CInt(row("Quantity"))
            If quantity >= 1 Then
                ' Append the food item and its quantity to the orderItems StringBuilder
                orderItems.AppendLine(row("Food Item").ToString() & " - " & quantity.ToString() & "%0A")
            End If
        Next

        ' Update Label3.Text with the order items
        Label22.Text = orderItems.ToString()

        Dim phoneNumber As String = "+6" & TextBox5.Text
        Dim message As String = ("Hello, " & fname & "%0A" &
                        "This is what you ordered: " & "%0A" & Label22.Text & "%0A" &
                        "It will be delivered to " & address & "%0A" &
                        "The Total Price is " & price & "%0A" &
                        "Wish you a nice day!")
        Try
            Dim web As New WebBrowser
            web.Navigate("WhatsApp://send?phone=" & phoneNumber & "&text=" & message)
            Timer3.Start()
        Catch ex As Exception
            Timer3.Stop()
        End Try

        'NewCodeToReset
        MessageBox.Show("A receipt of your order has been sent to WhatsApp, You will be redirected to homepage", "Order Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        For Each row As DataRow In Me.Database2DataSet1.Table2.Rows
            ' Set Quantity and Price to 0
            row("Quantity") = 0
            row("Price") = 0
        Next

        ' Update the database and refresh the table
        Me.Table2TableAdapter.Update(Me.Database2DataSet1.Table2)
        Me.Table2TableAdapter.Fill(Me.Database2DataSet1.Table2)
        Dim colsum As Decimal = 0
        For Each R As DataGridViewRow In DataGridView2.Rows
            colsum += CDec(R.Cells(3).Value)
        Next

        Label21.Text = "RM" + colsum.ToString()
        Label3.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = "0"
        TextBox5.Text = ""

        ' Assuming ComboBox1 contains plain string items


        MainOrder.Show()
        Me.Hide()

    End Sub
    Private Sub WebBrowser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
        Timer3.Start()
    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim selectedLocation As String = ComboBox1.SelectedItem("Location").ToString()

        ' Find the row with the selected location
        Dim rows As DataRow() = Me.Database1DataSet1.Table1.Select("Location = '" & selectedLocation & "'")

            ' Ensure that the row exists
            If rows.Length > 0 Then
            Dim selectedRow As DataRow = rows(0)
            Dim str1 As String = selectedRow.Item("Time").ToString()
            Dim str2 As String = selectedRow.Item("Kilometre").ToString()
            Dim str3 As String = selectedRow.Item("Location").ToString()

            ' Update the labels
            Label16.Text = str1 & " Minutes"
            Label17.Text = str2 & " Kilometre"
            Label23.Text = str3
        Else
            MessageBox.Show("Location not found.")
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MainOrder.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Table2TableAdapter.Update(Me.Database2DataSet1.Table2)
        Me.Table2TableAdapter.Fill(Me.Database2DataSet1.Table2)

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = True
        Me.Table2TableAdapter.Update(Me.Database2DataSet1.Table2)
        Me.Table2TableAdapter.Fill(Me.Database2DataSet1.Table2)
        ComboBox1.DataSource = Me.Database1DataSet1.Table1
        ComboBox1.DisplayMember = "Location"
        ComboBox1.ValueMember = "ID"  ' Optional: If you want to use the ID as the value member

        Dim orderItems As New System.Text.StringBuilder()

        ' Loop through each row in the DataTable
        For Each row As DataRow In Me.Database2DataSet1.Table2.Rows
            ' Check if the quantity is greater than or equal to 1
            Dim quantity As Integer = CInt(row("Quantity"))
            If quantity >= 1 Then
                ' Append the food item and its quantity to the orderItems StringBuilder
                orderItems.AppendLine(row("Food Item").ToString() & " - " & quantity.ToString())
            End If
        Next

        ' Update Label3.Text with the order items
        Label3.Text = orderItems.ToString()

        Dim colsum As Decimal = 0
        For Each R As DataGridViewRow In DataGridView2.Rows
            colsum += CDec(R.Cells(3).Value)
        Next
        Label21.Text = "RM" + colsum.ToString()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label11.Text = Date.Now.ToString("dd - MMM - yyyy" + vbNewLine + "HH:mm:ss")
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Static sec As Integer
        sec += 1
        If sec = 10 Then
            SendKeys.Send("{ENTER}")
            Timer3.Stop()
            sec = 0
        End If

    End Sub

    Private Sub OrderingTutorialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderingTutorialToolStripMenuItem.Click
        Dim passcode As String = InputBox("Please enter the passcode:", "Passcode Required")

        ' Check if the passcode is correct
        If passcode = "ilovechicken" Then
            ' If the passcode is correct, show Form3 and hide the current form
            Form3.Show()
            Me.Hide()
        Else
            ' If the passcode is incorrect, show a message box with "Wrong Passcode"
            MessageBox.Show("Wrong Passcode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.SelectedItem.ToString() = "Debit Card" Then
            ' Show Label12 and TextBox4
            Label12.Visible = True
            TextBox4.Visible = True

            ' Clear TextBox4 text
            TextBox4.Text = ""
        ElseIf ComboBox3.SelectedItem.ToString() = "COD" Then
            ' Hide Label12 and TextBox4
            Label12.Visible = False
            TextBox4.Visible = False

            ' Set TextBox4 text to 0
            TextBox4.Text = "0"
        End If
    End Sub

    Private Sub Staff_Click(sender As Object, e As EventArgs) Handles Staff.Click

    End Sub
End Class