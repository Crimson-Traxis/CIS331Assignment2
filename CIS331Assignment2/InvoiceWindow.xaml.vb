Public Class InvoiceWindow

    Private order As CustomerOrder
    Public exiting As Boolean
    Private exitWithoutWaring As Boolean

    Public Sub New(order As CustomerOrder)

        ' This call is required by the designer.
        InitializeComponent()
        exiting = False
        exitWithoutWaring = False
        Me.order = order
        textBlockSpace.Text = " "
        UpdateGui()
    End Sub

    Private Sub RemoveTopping(topping As ToppingItem, args As EventArgs)
        wrapPanelToppings.Children.Remove(topping)
        RemoveHandler topping.RemoveItem, AddressOf RemoveTopping
        Dim temList As List(Of Topping) = New List(Of Topping)
        For Each toppingItem As ToppingItem In wrapPanelToppings.Children
            temList.Add(toppingItem.Topping)
        Next
        order.Toppings = temList
        UpdateGui()
    End Sub

    Private Sub UpdateGui()
        Dim areaCost As Decimal = Math.PI * ((order.PizzaSize / 2.0) ^ 2) * 0.07
        textBlockAreaCost.Text = areaCost.ToString("c")
        Dim crustCost As Decimal = 0
        If order.Crust <> Crust.Plain Then
            crustCost = 2.25
        End If
        textBlockCrustCost.Text = crustCost.ToString("c")
        Dim toppingCost As Decimal = order.Toppings.Count * 1.5
        textBlockToppingsCost.Text = toppingCost.ToString("c")
        textBlockPizzaQuantity.Text = order.PizzaQuantity
        textBlockGrandTotal.Text = ((areaCost + crustCost + toppingCost) * order.PizzaQuantity).ToString("c")
        wrapPanelToppings.Children.Clear()
        For Each pizzaTopping As Topping In order.Toppings
            Dim pizzaToppingItem As ToppingItem = New ToppingItem(pizzaTopping)
            AddHandler pizzaToppingItem.RemoveItem, AddressOf RemoveTopping
            wrapPanelToppings.Children.Add(pizzaToppingItem)
        Next
        textBlockCrust.Text = order.Crust.ToString()
        textBlockPizzaCount.Text = order.PizzaQuantity
        textBlockPizzaSize.Text = order.PizzaSize
        textBlockUser.Text = order.CustomerName

    End Sub

    Private Sub buttonChangeOrder_Click(sender As Object, e As RoutedEventArgs) Handles buttonChangeOrder.Click
        exitWithoutWaring = True
        Me.Close()
    End Sub

    Private Sub buttonSend_Click(sender As Object, e As RoutedEventArgs) Handles buttonSend.Click
        order.OrderCompleted = True
        exitWithoutWaring = True
        MessageBox.Show("|" & String.Format("{0,-12}", "|") & "|")
        Me.Close()
    End Sub

    Private Sub buttonPrint_Click(sender As Object, e As RoutedEventArgs) Handles buttonPrint.Click
        Dim printDialog As New PrintDialog()
        printDialog.PageRangeSelection = PageRangeSelection.AllPages
        Dim toPrint As Boolean = printDialog.ShowDialog()
        If toPrint Then
            Dim document As FlowDocument = New FlowDocument(New Paragraph(New Run(ConvertGuiToPrintableFormat())))
            document.FontFamily = New FontFamily("Courier New")
            document.FontSize = 12
            document.ColumnWidth = 400
            document.PageWidth = 555
            document.PageHeight = 600
            Dim pagenatorDoc As IDocumentPaginatorSource = document
            printDialog.PrintDocument(pagenatorDoc.DocumentPaginator, "Invoice")
        End If
    End Sub

    Private Sub buttonExit_Click(sender As Object, e As RoutedEventArgs) Handles buttonExit.Click
        Me.Close()
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        If Not exitWithoutWaring Then
            If MessageBox.Show("Are you sure you want to quit?", "Pizza Planet Order System", MessageBoxButton.YesNo) = MessageBoxResult.No Then
                e.Cancel = True
            Else
                exiting = True
            End If
        End If
    End Sub

    Private Function ConvertGuiToPrintableFormat() As String
        Dim formattedString As String = ""
        formattedString &= "=========================================================================" & Environment.NewLine
        formattedString &= "                             Pizza Planet Order                          " & Environment.NewLine
        formattedString &= "=========================================================================" & Environment.NewLine
        formattedString &= Environment.NewLine
        formattedString &= "Baking up some pizza goodness for " & order.CustomerName & Environment.NewLine
        formattedString &= Environment.NewLine
        formattedString &= "There will be " & order.PizzaQuantity & " " & order.PizzaSize & """ pizza(s) created by the little alien dudes!" & Environment.NewLine
        formattedString &= Environment.NewLine
        formattedString &= "Each pizza will have " & order.Crust.ToString().Replace("_", " ") & " stuffed crust" & Environment.NewLine
        formattedString &= Environment.NewLine
        formattedString &= "Here are the toppings requested:"
        formattedString &= Environment.NewLine
        For Each item As ToppingItem In wrapPanelToppings.Children
            formattedString &= "   "
            formattedString &= item.Topping.ToString().Replace("_", " ") & Environment.NewLine
        Next
        formattedString &= Environment.NewLine
        formattedString &= Environment.NewLine
        formattedString &= "Cost Per Pizza Summary: " & Environment.NewLine
        Dim areaCost As Decimal = Math.PI * ((order.PizzaSize / 2.0) ^ 2) * 0.07
        formattedString &= String.Format("{0,-30}", "Area Cost: ") & String.Format("{0,-5}", (areaCost).ToString("c")) & Environment.NewLine
        Dim crustCost As Decimal = 0
        If order.Crust <> Crust.Plain Then
            crustCost = 2.25
        End If
        formattedString &= String.Format("{0,-30}", "Crust Cost: ") & String.Format("{0,-5}", (crustCost.ToString("c"))) & Environment.NewLine
        Dim toppingCost As Decimal = order.Toppings.Count * 1.5
        formattedString &= String.Format("{0,-30}", "Toppings Cost: ") & String.Format("{0,-5}", (toppingCost).ToString("c")) & Environment.NewLine
        formattedString &= "-------------------------------------------------------------------------" & Environment.NewLine
        formattedString &= String.Format("{0,-30}", "Quantity Ordered: ") & String.Format("{0,-5}", (order.PizzaQuantity)) & Environment.NewLine
        formattedString &= "-------------------------------------------------------------------------" & Environment.NewLine
        formattedString &= String.Format("{0,-30}", "Grand Total: ") & String.Format("{0,-5}", ((areaCost + crustCost + toppingCost) * order.PizzaQuantity).ToString("c")) & Environment.NewLine
        formattedString &= Environment.NewLine
        formattedString &= "========================================================================="
        Return formattedString
    End Function
End Class
