Imports CIS331Assignment2

Class MainWindow

    Private exitWithoutWaring As Boolean

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        exitWithoutWaring = False

    End Sub

    Private Sub buttonPlaceOrder_Click(sender As Object, e As RoutedEventArgs) Handles buttonPlaceOrder.Click
        Dim top As ToppingItem = New ToppingItem()
        top.Topping = Topping.Anchovies
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
                    pizzaToppings.Add([Enum].Parse(GetType(Topping), CStr(value)))
                End If
            End If
        Next
        Return New CustomerOrder(customername, pizzaSize, pizzaQuantity, pizzaCrust, pizzaToppings)
    End Function

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        If Not exitWithoutWaring Then
            MessageBox.Show("Sorry but the application can only be closed on the Invoice Screen. Please press place order to go to that screen...")
            e.Cancel = True
        End If
    End Sub
End Class
