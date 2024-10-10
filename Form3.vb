Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database4DataSet3.Table4' table. You can move, or remove it, as needed.
        Me.Table4TableAdapter.Fill(Me.Database4DataSet3.Table4)

        'TODO: This line of code loads data into the 'Database3DataSet.Table3' table. You can move, or remove it, as needed.
        Me.Table3TableAdapter.Fill(Me.Database3DataSet.Table3)
        'TODO: This line of code loads data into the 'Database2DataSet2.Table2' table. You can move, or remove it, as needed.
        Me.Table2TableAdapter.Fill(Me.Database2DataSet2.Table2)
        'TODO: This line of code loads data into the 'Database1DataSet.Table1' table. You can move, or remove it, as needed.
        Me.Table1TableAdapter.Fill(Me.Database1DataSet.Table1)
        Timer1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim str1, str2, str3 As String

        str1 = TextBox2.Text
        str2 = TextBox3.Text
        str3 = TextBox4.Text
        Me.Table1TableAdapter.Insert(str1, str2, str3)
        Me.Table1TableAdapter.Update(Me.Database1DataSet.Table1)
        Me.Table1TableAdapter.Fill(Me.Database1DataSet.Table1)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label11.Text = Date.Now.ToString("dd-MM-yyyy HH:mm:ss")
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim x As Integer
        x = TextBox1.Text


        ' Find the row with ID 1
        Dim existingRow As DataRow = Me.Database4DataSet3.Table4.Rows.Find(x)

        If existingRow IsNot Nothing Then
            existingRow(10) = "Fulfilled"

            ' Update the database and refresh the table
            Me.Table4TableAdapter.Update(Me.Database4DataSet3.Table4)
            Me.Table4TableAdapter.Fill(Me.Database4DataSet3.Table4)

            MessageBox.Show("Location with ID " & x & " has been updated to " & x)
        Else
            MessageBox.Show("Location with ID " + x + "Does not Exists")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim x, kilo, minutes As Integer
        x = TextBox10.Text
        kilo = TextBox9.Text
        minutes = TextBox8.Text



        ' Find the row with ID 1
        Dim existingRow As DataRow = Me.Database1DataSet.Table1.Rows.Find(x)

        If existingRow IsNot Nothing Then
            existingRow(2) = kilo
            existingRow(3) = minutes

            ' Update the database and refresh the table
            Me.Table1TableAdapter.Update(Me.Database1DataSet.Table1)
            Me.Table1TableAdapter.Fill(Me.Database1DataSet.Table1)

            MessageBox.Show("Item with ID " & x & " has been updated to 'Fulfilled'.")
        Else
            MessageBox.Show("Item with ID " + x + "Does not Exists")
        End If
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim x As Integer
        Dim newname As String
        x = CInt(TextBox7.Text)
        newname = TextBox6.Text



        ' Find the row with ID 1
        Dim existingRow As DataRow = Me.Database2DataSet2.Table2.Rows.Find(x)

        If existingRow IsNot Nothing Then
            existingRow(1) = newname

            ' Update the database and refresh the table
            Me.Table2TableAdapter.Update(Me.Database2DataSet2.Table2)
            Me.Table2TableAdapter.Fill(Me.Database2DataSet2.Table2)

            MessageBox.Show("Item with ID " & x & " has been updated to " & newname)
        Else
            MessageBox.Show("Item with ID " & x & "Does not Exists")
        End If
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub Staff_Click(sender As Object, e As EventArgs) Handles Staff.Click
        MainOrder.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim x As Integer
        x = TextBox5.Text



        Dim existingRow As DataRow = Me.Database4DataSet3.Table4.Rows.Find(x)

        If existingRow IsNot Nothing Then
            ' Retrieve all column values from the DataRow
            Dim id As String = existingRow("ID").ToString()
            Dim fName As String = existingRow("FName").ToString()
            Dim lName As String = existingRow("LName").ToString()
            Dim phone As String = existingRow("Phone").ToString()
            Dim address As String = existingRow("Address").ToString()
            Dim district As String = existingRow("District").ToString()
            Dim payment As String = existingRow("Payment").ToString()
            Dim card As String = existingRow("Card").ToString()
            Dim details As String = existingRow("Details").ToString()
            Dim price As String = existingRow("Price").ToString()
            Dim process As String = existingRow("Process").ToString()
            Dim time As String = existingRow("Time").ToString()

            ' Format the string to print 
            Dim printText As String = ($"ID: {id}" & vbNewLine &
                                      $"First Name: {fName}" & vbNewLine &
                                      $"Last Name: {lName}" & vbNewLine &
                                      $"Phone: +60{phone}" & vbNewLine &
                                      $"Address: {address}" & vbNewLine &
                                      $"District: {district}" & vbNewLine &
                                      $"Payment: {payment}" & vbNewLine &
                                      $"Card: {card}" & vbNewLine &
                                      $"Details: {details}" & vbNewLine &
                                      $"Price: {price}" & vbNewLine &
                                      $"Process: {process}" & vbNewLine &
                                      $"Time: {time}")

            ' Print the formatted string
            e.Graphics.DrawString(printText, New Font("Gill Sans Ultra Bold", 17, FontStyle.Bold), Brushes.Black, New PointF(100, 100))

        Else
            MessageBox.Show("Item with ID " & x & " does not exist.")
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If PrintPreviewDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub DataGridView4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class