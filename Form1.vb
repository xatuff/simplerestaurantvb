Public Class MainOrder
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database2DataSet.Table2' table. You can move, or remove it, as needed.
        Me.Table2TableAdapter.Fill(Me.Database2DataSet.Table2)
        'TODO: This line of code loads data into the 'Database1DataSet2.Table1' table. You can move, or remove it, as needed.
        Me.Table1TableAdapter.Fill(Me.Database1DataSet2.Table1)

        Dim orderItems As New System.Text.StringBuilder()

        ' Loop through each row in the DataTable
        For Each row As DataRow In Me.Database2DataSet.Table2.Rows
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

        Label20.Text = "RM" + colsum.ToString()
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub AboutApplicationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Staff.Click

    End Sub

    Private Sub StaffTestToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Form2ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Form2ToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim orderItems As New System.Text.StringBuilder()
        Dim int1 As Integer = 1
        Dim int2 As Decimal = 7


        ' Find the row with ID 1
        Dim existingRow As DataRow = Me.Database2DataSet.Table2.Rows.Find(1)

        If existingRow IsNot Nothing Then
            ' Update the existing row

            ' Increase the quantity by 1 if it's greater than or equal to 1
            Dim currentQuantity As Integer = CInt(existingRow("Quantity"))

            If currentQuantity >= 0 Then
                existingRow("Quantity") = currentQuantity + 1

                ' Update the price
                Dim updatedPrice As Decimal = CInt(existingRow("Quantity")) * int2
                existingRow("Price") = updatedPrice

                ' Loop through each row in the DataTable
                For Each row As DataRow In Me.Database2DataSet.Table2.Rows
                    ' Check if the quantity is greater than or equal to 1
                    Dim quantity As Integer = CInt(row("Quantity"))
                    If quantity >= 1 Then
                        ' Append the food item to the orderItems StringBuilder
                        orderItems.AppendLine(row("Food Item").ToString() & " - " & quantity.ToString())
                    End If
                Next

                ' Update Label3.Text with the order items
                Label3.Text = orderItems.ToString()

                ' Update the database and refresh the table
                Me.Table2TableAdapter.Update(Me.Database2DataSet.Table2)
                Me.Table2TableAdapter.Fill(Me.Database2DataSet.Table2)

                ' Calculate the sum of the total price
                Dim colsum As Decimal = 0
                For Each R As DataGridViewRow In DataGridView2.Rows
                    colsum += CDec(R.Cells(3).Value)
                Next

                Label20.Text = "RM" + colsum.ToString()

            End If
        Else
            MessageBox.Show("Item with ID 1 not found.")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim existingRow As DataRow = Me.Database2DataSet.Table2.Rows.Find(31)

        If existingRow IsNot Nothing Then
            ' Update the "Price" column to 0
            existingRow("Price") = 0

            ' Update the database and refresh the table
            Me.Table2TableAdapter.Update(Me.Database2DataSet.Table2)
            Me.Table2TableAdapter.Fill(Me.Database2DataSet.Table2)

            MessageBox.Show("Price updated to 0 for item with ID 31.")
        Else
            MessageBox.Show("Item with ID 31 not found.")
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim orderItems As New System.Text.StringBuilder()
        Dim int1 As Integer = 1
        Dim int2 As Decimal = 7


        ' Find the row with ID 1
        Dim existingRow As DataRow = Me.Database2DataSet.Table2.Rows.Find(1)

        If existingRow IsNot Nothing Then
            ' Update the existing row

            ' Increase the quantity by 1 if it's greater than or equal to 1
            Dim currentQuantity As Integer = CInt(existingRow("Quantity"))

            If currentQuantity >= 1 Then
                existingRow("Quantity") = currentQuantity - 1

                ' Update the price
                Dim updatedPrice As Decimal = CInt(existingRow("Quantity")) * int2
                existingRow("Price") = updatedPrice

                ' Loop through each row in the DataTable
                For Each row As DataRow In Me.Database2DataSet.Table2.Rows
                    ' Check if the quantity is greater than or equal to 1
                    Dim quantity As Integer = CInt(row("Quantity"))
                    If quantity >= 1 Then
                        ' Append the food item to the orderItems StringBuilder
                        orderItems.AppendLine(row("Food Item").ToString() & " - " & quantity.ToString())
                    End If
                Next

                ' Update Label3.Text with the order items
                Label3.Text = orderItems.ToString()

                ' Update the database and refresh the table
                Me.Table2TableAdapter.Update(Me.Database2DataSet.Table2)
                Me.Table2TableAdapter.Fill(Me.Database2DataSet.Table2)

                ' Calculate the sum of the total price
                Dim colsum As Decimal = 0
                For Each R As DataGridViewRow In DataGridView2.Rows
                    colsum += CDec(R.Cells(3).Value)
                Next

                Label20.Text = "RM" + colsum.ToString()

            End If
        Else
            MessageBox.Show("Item with ID 1 not found.")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim str1 As String
        Dim str2 As Integer
        Dim str3 As Decimal

        str1 = Label14.Text
        str2 = 0
        str3 = 0
        Me.Table2TableAdapter.Insert(str1, str2, str3)
        Me.Table2TableAdapter.Update(Me.Database2DataSet.Table2)
        Me.Table2TableAdapter.Fill(Me.Database2DataSet.Table2)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim orderItems As New System.Text.StringBuilder()
        Dim int1 As Integer = 1
        Dim int2 As Decimal = 20


        ' Find the row with ID 1
        Dim existingRow As DataRow = Me.Database2DataSet.Table2.Rows.Find(30)

        If existingRow IsNot Nothing Then
            ' Update the existing row

            ' Increase the quantity by 1 if it's greater than or equal to 1
            Dim currentQuantity As Integer = CInt(existingRow("Quantity"))

            If currentQuantity >= 0 Then
                existingRow("Quantity") = currentQuantity + 1

                ' Update the price
                Dim updatedPrice As Decimal = CInt(existingRow("Quantity")) * int2
                existingRow("Price") = updatedPrice

                ' Loop through each row in the DataTable
                For Each row As DataRow In Me.Database2DataSet.Table2.Rows
                    ' Check if the quantity is greater than or equal to 1
                    Dim quantity As Integer = CInt(row("Quantity"))
                    If quantity >= 1 Then
                        ' Append the food item to the orderItems StringBuilder
                        orderItems.AppendLine(row("Food Item").ToString() & " - " & quantity.ToString())
                    End If
                Next

                ' Update Label3.Text with the order items
                Label3.Text = orderItems.ToString()

                ' Update the database and refresh the table
                Me.Table2TableAdapter.Update(Me.Database2DataSet.Table2)
                Me.Table2TableAdapter.Fill(Me.Database2DataSet.Table2)

                ' Calculate the sum of the total price
                Dim colsum As Decimal = 0
                For Each R As DataGridViewRow In DataGridView2.Rows
                    colsum += CDec(R.Cells(3).Value)
                Next

                Label20.Text = "RM" + colsum.ToString()

            End If
        Else
            MessageBox.Show("Item with ID 31 not found.")
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim orderItems As New System.Text.StringBuilder()
        Dim int1 As Integer = 1
        Dim int2 As Decimal = 20


        ' Find the row with ID 1
        Dim existingRow As DataRow = Me.Database2DataSet.Table2.Rows.Find(30)

        If existingRow IsNot Nothing Then
            ' Update the existing row

            ' Increase the quantity by 1 if it's greater than or equal to 1
            Dim currentQuantity As Integer = CInt(existingRow("Quantity"))

            If currentQuantity >= 1 Then
                existingRow("Quantity") = currentQuantity - 1

                ' Update the price
                Dim updatedPrice As Decimal = CInt(existingRow("Quantity")) * int2
                existingRow("Price") = updatedPrice

                ' Loop through each row in the DataTable
                For Each row As DataRow In Me.Database2DataSet.Table2.Rows
                    ' Check if the quantity is greater than or equal to 1
                    Dim quantity As Integer = CInt(row("Quantity"))
                    If quantity >= 1 Then
                        ' Append the food item to the orderItems StringBuilder
                        orderItems.AppendLine(row("Food Item").ToString() & " - " & quantity.ToString())
                    End If
                Next

                ' Update Label3.Text with the order items
                Label3.Text = orderItems.ToString()

                ' Update the database and refresh the table
                Me.Table2TableAdapter.Update(Me.Database2DataSet.Table2)
                Me.Table2TableAdapter.Fill(Me.Database2DataSet.Table2)

                ' Calculate the sum of the total price
                Dim colsum As Decimal = 0
                For Each R As DataGridViewRow In DataGridView2.Rows
                    colsum += CDec(R.Cells(3).Value)
                Next

                Label20.Text = "RM" + colsum.ToString()

            End If
        Else
            MessageBox.Show("Item with ID 31 not found.")
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim orderItems As New System.Text.StringBuilder()
        Dim int1 As Integer = 1
        Dim int2 As Decimal = 8


        ' Find the row with ID 1
        Dim existingRow As DataRow = Me.Database2DataSet.Table2.Rows.Find(31)

        If existingRow IsNot Nothing Then
            ' Update the existing row

            ' Increase the quantity by 1 if it's greater than or equal to 1
            Dim currentQuantity As Integer = CInt(existingRow("Quantity"))

            If currentQuantity >= 0 Then
                existingRow("Quantity") = currentQuantity + 1

                ' Update the price
                Dim updatedPrice As Decimal = CInt(existingRow("Quantity")) * int2
                existingRow("Price") = updatedPrice

                ' Loop through each row in the DataTable
                For Each row As DataRow In Me.Database2DataSet.Table2.Rows
                    ' Check if the quantity is greater than or equal to 1
                    Dim quantity As Integer = CInt(row("Quantity"))
                    If quantity >= 1 Then
                        ' Append the food item to the orderItems StringBuilder
                        orderItems.AppendLine(row("Food Item").ToString() & " - " & quantity.ToString())
                    End If
                Next

                ' Update Label3.Text with the order items
                Label3.Text = orderItems.ToString()

                ' Update the database and refresh the table
                Me.Table2TableAdapter.Update(Me.Database2DataSet.Table2)
                Me.Table2TableAdapter.Fill(Me.Database2DataSet.Table2)

                ' Calculate the sum of the total price
                Dim colsum As Decimal = 0
                For Each R As DataGridViewRow In DataGridView2.Rows
                    colsum += CDec(R.Cells(3).Value)
                Next

                Label20.Text = "RM" + colsum.ToString()

            End If
        Else
                MessageBox.Show("Item with ID 31 not found.")
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim orderItems As New System.Text.StringBuilder()
        Dim int1 As Integer = 1
        Dim int2 As Decimal = 8


        ' Find the row with ID 31
        Dim existingRow As DataRow = Me.Database2DataSet.Table2.Rows.Find(31)

        If existingRow IsNot Nothing Then
            ' Update the existing row

            ' Increase the quantity by 1 if it's greater than or equal to 1
            Dim currentQuantity As Integer = CInt(existingRow("Quantity"))

            If currentQuantity >= 1 Then
                existingRow("Quantity") = currentQuantity - 1

                ' Update the price
                Dim updatedPrice As Decimal = CInt(existingRow("Quantity")) * int2
                existingRow("Price") = updatedPrice

                ' Loop through each row in the DataTable
                For Each row As DataRow In Me.Database2DataSet.Table2.Rows
                    ' Check if the quantity is greater than or equal to 1
                    Dim quantity As Integer = CInt(row("Quantity"))
                    If quantity >= 1 Then
                        ' Append the food item to the orderItems StringBuilder
                        orderItems.AppendLine(row("Food Item").ToString() & " - " & quantity.ToString())
                    End If
                Next

                ' Update Label3.Text with the order items
                Label3.Text = orderItems.ToString()

                ' Update the database and refresh the table
                Me.Table2TableAdapter.Update(Me.Database2DataSet.Table2)
                Me.Table2TableAdapter.Fill(Me.Database2DataSet.Table2)

                ' Calculate the sum of the total price
                Dim colsum As Decimal = 0
                For Each R As DataGridViewRow In DataGridView2.Rows
                    colsum += CDec(R.Cells(3).Value)
                Next

                Label20.Text = "RM" + colsum.ToString()

            End If
        Else
            MessageBox.Show("Item with ID 31 not found.")
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

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If Label20.Text = "RM0" Then
            ' Show a message box with a warning icon
            MessageBox.Show("You must order anything to continue", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            ' Show Form2
            Form2.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim existingRow As DataRow = Me.Database2DataSet.Table2.Rows.Find(31)

        If existingRow IsNot Nothing Then
            ' Update the "Food Item" column to "Friend Chicken Set"
            existingRow("Food Item") = "Crispy Chicken Burger"

            ' Update the database and refresh the table
            Me.Table2TableAdapter.Update(Me.Database2DataSet.Table2)
            Me.Table2TableAdapter.Fill(Me.Database2DataSet.Table2)

            MessageBox.Show("Food Item updated to 'Friend Chicken Set' for item with ID 1.")
        Else
            MessageBox.Show("Item with ID 1 not found.")
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label11.Text = Date.Now.ToString("dd - MMM - yyyy" + vbNewLine + "HH:mm:ss")
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        For Each row As DataRow In Me.Database2DataSet.Table2.Rows
            ' Set Quantity and Price to 0
            row("Quantity") = 0
            row("Price") = 0
        Next

        ' Update the database and refresh the table
        Me.Table2TableAdapter.Update(Me.Database2DataSet.Table2)
        Me.Table2TableAdapter.Fill(Me.Database2DataSet.Table2)
        Dim colsum As Decimal = 0
        For Each R As DataGridViewRow In DataGridView2.Rows
            colsum += CDec(R.Cells(3).Value)
        Next

        Label20.Text = "RM" + colsum.ToString()
        Label3.Text = ""

        MessageBox.Show("All quantities and prices have been reset to 0.")
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Enabled = True
        Me.Table2TableAdapter.Update(Me.Database2DataSet.Table2)
        Me.Table2TableAdapter.Fill(Me.Database2DataSet.Table2)


        Dim orderItems As New System.Text.StringBuilder()

        ' Loop through each row in the DataTable
        For Each row As DataRow In Me.Database2DataSet.Table2.Rows
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
        Label20.Text = "RM" + colsum.ToString()
    End Sub
End Class
