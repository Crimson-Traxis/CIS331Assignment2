Public Class CustomerOrder

    Private _customerName As String
    Private _pizzaSize As Integer
    Private _pizzaQuantity As Integer
    Private _crust As Crust
    Private _toppings As List(Of Topping)
    Private _orderCompleted As Boolean

    Public Sub New()
        _customerName = ""
        _pizzaSize = 0
        _pizzaQuantity = 0
        _crust = Crust.Plain
        _toppings = New List(Of Topping)
        _orderCompleted = False
    End Sub

    Public Sub New(customerName As String, pizzaSize As Integer, pizzaQuantity As Integer, crust As Crust, toppings As List(Of Topping))
        _customerName = customerName
        _pizzaSize = pizzaSize
        _pizzaQuantity = pizzaQuantity
        _crust = crust
        _toppings = toppings
        _orderCompleted = False
    End Sub

    Public Property CustomerName() As String
        Get
            Return _customerName
        End Get
        Set(ByVal value As String)
            _customerName = value
        End Set
    End Property

    Public Property PizzaSize() As Integer
        Get
            Return _pizzaSize
        End Get
        Set(ByVal value As Integer)
            _pizzaSize = value
        End Set
    End Property

    Public Property PizzaQuantity() As Integer
        Get
            Return _pizzaQuantity
        End Get
        Set(ByVal value As Integer)
            _pizzaQuantity = value
        End Set
    End Property

    Public Property Crust() As Crust
        Get
            Return _crust
        End Get
        Set(ByVal value As Crust)
            _crust = value
        End Set
    End Property

    Public Property Toppings() As List(Of Topping)
        Get
            Return _toppings
        End Get
        Set(ByVal value As List(Of Topping))
            _toppings = value
        End Set
    End Property

    Public Property OrderCompleted() As Boolean
        Get
            Return _orderCompleted
        End Get
        Set(ByVal value As Boolean)
            _orderCompleted = value
        End Set
    End Property
End Class
