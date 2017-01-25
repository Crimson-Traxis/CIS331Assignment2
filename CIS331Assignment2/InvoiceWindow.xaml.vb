
'------------------------------------------------------------ 
'-                File Name : InvoiceWindow.xaml.vb         - 
'-                Part of Project: Assignment 2             - 
'------------------------------------------------------------
'-                Written By: Trent Killinger               - 
'-                Written On: 1-14-17                       - 
'------------------------------------------------------------ 
'- File Purpose:                                            - 
'-                                                          - 
'- This file is contains the invoice gui where the user     -
'- cant see the calculated cost of their order. The user    -
'- has the ability to change their order, send their order  -
'- to the kitchen, print, or exit the application           -
'------------------------------------------------------------
'- Variable Dictionary                                      - 
'- order - order object containing customer order data      -
'- exiting - tells mainwindow if user wants to exit app     -
'- exitWithoutWaring - allows exiting window without warning-
'-                     ex. to change order or new order     -
'- cheeseTopping - topping item that cannot be removed      -
'------------------------------------------------------------
Public Class InvoiceWindow

    Private order As CustomerOrder
    Public exiting As Boolean
    Private exitWithoutWaring As Boolean
    Private cheeseTopping As ToppingItem

    '------------------------------------------------------------ 
    '-                Subprogram Name: New                      - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine creates the gui and instantiates default -
    '- member data/objects. The sub also adds the toppings to   -
    '- the view.
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- (None)                                                   - 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- pizzaToppingItem - pizza topping item to be created from -
    '-                    topping enumeration                   -
    '------------------------------------------------------------
    Public Sub New(order As CustomerOrder)

        InitializeComponent()
        exiting = False
        exitWithoutWaring = False
        Me.order = order
        textBlockSpace.Text = " "
        cheeseTopping = New ToppingItem(Topping.Cheese)
        cheeseTopping.RemoveButtonVisibility = Visibility.Hidden
        wrapPanelToppings.Children.Add(cheeseTopping)
        For Each pizzaTopping As Topping In order.Toppings
            Dim pizzaToppingItem As ToppingItem = New ToppingItem(pizzaTopping)
            AddHandler pizzaToppingItem.RemoveItem, AddressOf RemoveTopping
            wrapPanelToppings.Children.Add(pizzaToppingItem)
        Next
        UpdateGui()
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: RemoveTopping            - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine removes a topping from the wrap panel    -
    '- that contains the topping and the order topping list     -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- topping – Identifies which particular control raised the - 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -    
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub RemoveTopping(topping As ToppingItem, e As EventArgs)
        wrapPanelToppings.Children.Remove(topping)
        RemoveHandler topping.RemoveItem, AddressOf RemoveTopping
        order.Toppings.Remove(topping.Topping)
        UpdateGui()
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: UpdateGui                - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine updates the gui and calcualtes the costs -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- (None)                                                   - 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- areaCost - cost of the pizza in in^2                     -
    '- crustCost - cost of the crust                            -
    '- toppingCost - cost of the topping                        -
    '------------------------------------------------------------
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
        textBlockCrust.Text = order.Crust.ToString()
        textBlockPizzaCount.Text = order.PizzaQuantity
        textBlockPizzaSize.Text = order.PizzaSize
        textBlockUser.Text = order.CustomerName

    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: buttonChangeOrder_Click  - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-11-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine exits the invoice window withoug a       -
    '- warning                                                  -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- sender – Identifies which particular control raised the  - 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -    
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- (None)                                                   - 
    '------------------------------------------------------------
    Private Sub buttonChangeOrder_Click(sender As Object, e As RoutedEventArgs) Handles buttonChangeOrder.Click
        exitWithoutWaring = True
        Me.Close()
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: buttonSend_Click         - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-11-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine exits the invoice window withoug a       -
    '- warning and sets the order to completed, allowing the    -
    '- main window to reset its gui                             -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- sender – Identifies which particular control raised the  - 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -    
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- (None)                                                   - 
    '------------------------------------------------------------
    Private Sub buttonSend_Click(sender As Object, e As RoutedEventArgs) Handles buttonSend.Click
        order.OrderCompleted = True
        exitWithoutWaring = True
        Me.Close()
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: buttonPrint_Click        - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-11-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine show a print dialog box then prints the  -
    '- data in a nice format for the user                       -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- sender – Identifies which particular control raised the  - 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -    
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- printdialog - the print dialog                           -
    '- toPrint - true if the user wants to print                -
    '- document - flowdocument that formats text for printing   -
    '- source - source of printable object                      -
    '------------------------------------------------------------
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
            Dim source As IDocumentPaginatorSource = document
            printDialog.PrintDocument(source.DocumentPaginator, "Invoice")
        End If
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: buttonExit_Click         - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-11-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine closes the invoice window                -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- sender – Identifies which particular control raised the  - 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -    
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub buttonExit_Click(sender As Object, e As RoutedEventArgs) Handles buttonExit.Click
        Me.Close()
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: Window_Closing           - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-11-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine closes the invoice window if the user    -
    '- confirms closing after messagebox. Sub also sets exitying-
    '- to true, informing mainwindow to close itself            -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- sender – Identifies which particular control raised the  - 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -    
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- (none)                                                   -
    '------------------------------------------------------------
    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        If Not exitWithoutWaring Then
            If MessageBox.Show("Are you sure you want to quit?", "Pizza Planet Order System", MessageBoxButton.YesNo) = MessageBoxResult.No Then
                e.Cancel = True
            Else
                exiting = True
            End If
        End If
    End Sub

    '------------------------------------------------------------ 
    '-        Function Name: ConvertGuiToPrintableFormat        - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Function Purpose:                                        - 
    '-                                                          - 
    '- This Function creates a string from the order data       -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- (None)                                                   -   
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- formattedString - string to be returned
    '- areaCost - cost of the pizza in in^2                     -
    '- crustCost - cost of the crust                            -
    '- toppingCost - cost of the topping                        -
    '------------------------------------------------------------
    '- Returns                                                  - 
    '- string created from window data                          - 
    '------------------------------------------------------------
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
        formattedString &= "Here are the toppings requested:" & Environment.NewLine
        formattedString &= "   Cheese (automatic at not cost!)" & Environment.NewLine
        For Each item As ToppingItem In wrapPanelToppings.Children
            If item.Topping <> Topping.Cheese Then
                formattedString &= "   "
                formattedString &= item.Topping.ToString().Replace("_", " ") & Environment.NewLine
            End If
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
