'------------------------------------------------------------ 
'-                File Name : CustomerOrder.vb              - 
'-                Part of Project: Assignment 2             - 
'------------------------------------------------------------
'-                Written By: Trent Killinger               - 
'-                Written On: 1-14-17                       - 
'------------------------------------------------------------ 
'- File Purpose:                                            - 
'-                                                          - 
'- This file is contains the class definition for a customer-
'- order                                                    -
'------------------------------------------------------------
'- Variable Dictionary                                      - 
'- _customerName – customers name                           -
'- _pizzaSize - pizzas size                                 -
'- _pizzaQuantity - number of pizzas ordered                -
'- _crust - pizzas crust                                    -
'- _toppings - list of pizza toppings                       -
'- _orderCompleted - order status                           -
'------------------------------------------------------------
Public Class CustomerOrder

    Private _customerName As String
    Private _pizzaSize As Integer
    Private _pizzaQuantity As Integer
    Private _crust As Crust
    Private _toppings As List(Of Topping)
    Private _orderCompleted As Boolean

    '------------------------------------------------------------ 
    '-                Subprogram Name: New                      - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine creates the control and set inital values-
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- (None)                                                   - 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- (None)                                                   - 
    '------------------------------------------------------------
    Public Sub New()
        _customerName = ""
        _pizzaSize = 0
        _pizzaQuantity = 0
        _crust = Crust.Plain
        _toppings = New List(Of Topping)
        _orderCompleted = False
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: New                      - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine creates the control and set inital values-
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- customerName – customers name                           -
    '- pizzaSize - pizzas size                                 -
    '- pizzaQuantity - number of pizzas ordered                -
    '- crust - pizzas crust                                    -
    '- toppings - list of pizza toppings                       -
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- (None)                                                   - 
    '------------------------------------------------------------
    Public Sub New(customerName As String, pizzaSize As Integer, pizzaQuantity As Integer, crust As Crust, toppings As List(Of Topping))
        _customerName = customerName
        _pizzaSize = pizzaSize
        _pizzaQuantity = pizzaQuantity
        _crust = crust
        _toppings = toppings
        _orderCompleted = False
    End Sub

    '------------------------------------------------------------ 
    '-                Property Name: CustomerName               - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Property Purpose:                                        - 
    '-                                                          - 
    '- This Property sets/sets the customer name                -
    '------------------------------------------------------------ 
    Public Property CustomerName() As String
        Get
            Return _customerName
        End Get
        Set(ByVal value As String)
            _customerName = value
        End Set
    End Property


    '------------------------------------------------------------ 
    '-                Property Name: PizzaSize                  - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Property Purpose:                                        - 
    '-                                                          - 
    '- This Property sets/sets the pizza size                   -
    '------------------------------------------------------------ 
    Public Property PizzaSize() As Integer
        Get
            Return _pizzaSize
        End Get
        Set(ByVal value As Integer)
            _pizzaSize = value
        End Set
    End Property


    '------------------------------------------------------------ 
    '-                Property Name: PizzaQuantity              - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Property Purpose:                                        - 
    '-                                                          - 
    '- This Property sets/sets the pizza quantity               -
    '------------------------------------------------------------ 
    Public Property PizzaQuantity() As Integer
        Get
            Return _pizzaQuantity
        End Get
        Set(ByVal value As Integer)
            _pizzaQuantity = value
        End Set
    End Property

    '------------------------------------------------------------ 
    '-                Property Name: PizzaQuantity              - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Property Purpose:                                        - 
    '-                                                          - 
    '- This Property sets/sets the pizza crust                  -
    '------------------------------------------------------------ 
    Public Property Crust() As Crust
        Get
            Return _crust
        End Get
        Set(ByVal value As Crust)
            _crust = value
        End Set
    End Property

    '------------------------------------------------------------ 
    '-                Property Name: PizzaQuantity              - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Property Purpose:                                        - 
    '-                                                          - 
    '- This Property sets/sets the pizza toppings               -
    '------------------------------------------------------------ 
    Public Property Toppings() As List(Of Topping)
        Get
            Return _toppings
        End Get
        Set(ByVal value As List(Of Topping))
            _toppings = value
        End Set
    End Property

    '------------------------------------------------------------ 
    '-                Property Name: PizzaQuantity              - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Property Purpose:                                        - 
    '-                                                          - 
    '- This Property sets/sets the pizza order status           -
    '------------------------------------------------------------ 
    Public Property OrderCompleted() As Boolean
        Get
            Return _orderCompleted
        End Get
        Set(ByVal value As Boolean)
            _orderCompleted = value
        End Set
    End Property
End Class
