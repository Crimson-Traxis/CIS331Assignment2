Imports CIS331Assignment2
'------------------------------------------------------------ 
'-                File Name : MainWindow.xaml.vb            - 
'-                Part of Project: Assignment 2             - 
'------------------------------------------------------------
'-                Written By: Trent Killinger               - 
'-                Written On: 1-14-17                       - 
'------------------------------------------------------------ 
'- File Purpose:                                            - 
'-                                                          - 
'- This file is contains the main gui where the user will   -
'- input data for a pizza of their choice, they have the    -
'- option to select their pizza size and quantity. They can -
'- also select stuffed crust and toppings                   -
'------------------------------------------------------------
'- Variable Dictionary                                      - 
'- exitWithoutWaring - when set to true program can exit    -
'------------------------------------------------------------

Class MainWindow

    Private exitWithoutWaring As Boolean

    '------------------------------------------------------------ 
    '-                Subprogram Name: New                      - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine creates the gui and instantiates default -
    '- member data/objects                                      -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- (None)                                                   - 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- (None)                                                   - 
    '------------------------------------------------------------
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        exitWithoutWaring = False

    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: buttonPlaceOrder_Click   - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine creates a new instace of the invoice     -
    '- window and displays it to the user. After user exits     -
    '- the invoice window this sub checks if the user wants to  -
    '- completly exit the app, enter a new order, and updates   -
    '- toppings if they were removed from the invoice window    -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- sender – Identifies which particular control raised the  - 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -    
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- order - order object containing order data. Such as      -
    '-         customer name, pizza size, pizza quantiy ...     -
    '- InvoiceWin - Invoice window to be shown to the user      -
    '- toppingString - textual representation of topping        -
    '-                 enumeration                              -
    '- checkBox - textual representation of checkbox string     -
    '------------------------------------------------------------
    Private Sub buttonPlaceOrder_Click(sender As Object, e As RoutedEventArgs) Handles buttonPlaceOrder.Click
        Dim order As CustomerOrder = CreateOrder()
        Dim InvoiceWin As InvoiceWindow = New InvoiceWindow(order)
        Me.Visibility = Visibility.Hidden
        InvoiceWin.ShowDialog()
        If InvoiceWin.exiting Then
            exitWithoutWaring = True
            Me.Close()
        Else
            If order.OrderCompleted Then
                ClearGui()
            Else
                For Each checkBox As CheckBox In gridToppings.Children
                    checkBox.IsChecked = False
                    For Each topping As Topping In order.Toppings
                        Dim toppingString As String = topping.ToString().Replace("_", " ")
                        Dim checkBoxString As String = CStr(checkBox.Content)
                        If toppingString = checkBoxString Then
                            checkBox.IsChecked = True
                        End If
                    Next
                Next
            End If
            Me.Visibility = Visibility.Visible
        End If

    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: ClearGui                 - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine clears the gui                           -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- (None)                                                   -   
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- (None)                                                   - 
    '------------------------------------------------------------
    Private Sub ClearGui()
        textBoxCustName.Text = ""
        numberUpDownPizzaSize.Number = 5
        numberUpDownQuantity.Number = 0
        For Each radioButton As RadioButton In gridCrustSelection.Children
            radioButton.IsChecked = False
        Next
        radioButtonPlain.IsChecked = True
        For Each checkBox As CheckBox In gridToppings.Children
            checkBox.IsChecked = False
        Next
    End Sub


    '------------------------------------------------------------ 
    '-                Function Name: CreateOrder                - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Function Purpose:                                        - 
    '-                                                          - 
    '- This Function creates a order object from the form     -
    '- data
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- (None)                                                   -   
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- customername - customers name                            -
    '- pizzaSize - pizza's size                                 -
    '- pizzaQuantity - pizza's quantity                         -
    '- pizzaCrust - pizza's crust                               -
    '- pizzaToppings - list of pizza toppings                   -
    '- value - checkbox content                                 -
    '------------------------------------------------------------
    '- Returns                                                  - 
    '- CustomerOrder created from window data                   - 
    '------------------------------------------------------------
    Private Function CreateOrder() As CustomerOrder
        Dim customername As String = textBoxCustName.Text
        Dim pizzaSize As Integer = numberUpDownPizzaSize.Number
        Dim pizzaQuantity As Integer = numberUpDownQuantity.Number
        Dim pizzaCrust As Crust = Crust.Plain
        Dim pizzaToppings As List(Of Topping) = New List(Of Topping)
        For Each radioButton As RadioButton In gridCrustSelection.Children
            If radioButton.HasContent Then
                If radioButton.IsChecked Then
                    pizzaCrust = [Enum].Parse(GetType(Crust), CStr(radioButton.Content))
                    Exit For
                End If
            End If
        Next
        For Each checkBox As CheckBox In gridToppings.Children
            If checkBox.HasContent Then
                If checkBox.IsChecked Then
                    Dim value As String = checkBox.Content
                    value = value.Replace(" ", "_")
                    pizzaToppings.Add([Enum].Parse(GetType(Topping), value))
                End If
            End If
        Next
        Return New CustomerOrder(customername, pizzaSize, pizzaQuantity, pizzaCrust, pizzaToppings)
    End Function

    '------------------------------------------------------------ 
    '-                Subprogram Name: Window_Closing           - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine determines if the application can exit.  -
    '- If the user cannot exit a messagebox will be displayed   -
    '- to the user                                              -
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
            MessageBox.Show("Sorry but the application can only be closed on the Invoice Screen. Please press place order to go to that screen...")
            e.Cancel = True
        End If
    End Sub
End Class
