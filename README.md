# Draft

welcome 
this is a project for a cafe shop management 

``` cs 

    private async Task HandleValidSubmit()
    {
        // Calculate the total price and apply discounts
        _order.TotalPrice = CalculateTotalPrice(_order);
        _order.CreatedAt = DateTime.Now;

        // Save the order
        await SaveOrder(_order);

        // Reset the form
        _order = new Order();
    }

    private double CalculateTotalPrice(Order order)
    {
        // Calculate the base price
        if (_coffeesList != null)
        {
            var basePrice = _coffeesList.First(c => c.Guid == order.CoffeeId).Price;
            var addOnsPrice = order.AddOnIds.Sum(id =>
            {
                if (_addOnsList != null) return _addOnsList.First(a => a.Guid == id).AddOnPrice;
                return 0;
            });
            var priceBeforeDiscount = (basePrice + addOnsPrice) * order.Quantity;

            // Check if the customer is a regular customer (e.g., by phone number)
            if (_customersList != null)
            {
                var customer = _customersList.FirstOrDefault(c => c.PhoneNo == order.CustomerPhone);
            }

            bool isRegularCustomer = IsRegularCustomer(_searchPhoneNo); // You can enhance this check

            // Apply the discount
            var discountPercentage = isRegularCustomer ? 0.1 : 0;
            var totalPrice = priceBeforeDiscount * (1 - discountPercentage);

            return totalPrice;
        }

        return 0;
    }
    private bool IsRegularCustomer(string customerPhone)
    {
        // Find the customer
        if (_customersList != null)
        {
            var customer = _customersList.FirstOrDefault(c => c.PhoneNo == customerPhone);
            if (customer == null) return false; // Customer not found
        }

        FetchOrders();
        // Get the dates of the customer's past purchases
        if (_ordersList != null)
        {
            var purchaseDates = _ordersList.Where(o => o.CustomerPhone == customerPhone).Select(o => o.CreatedAt);

            // Check if the customer has made a purchase every day for a full month (excluding weekends)
            var lastMonth = DateTime.Now.AddMonths(-1);
            var daysInLastMonth = Enumerable.Range(0, DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month))
                .Select(day => new DateTime(lastMonth.Year, lastMonth.Month, day));
            var weekdaysInLastMonth = daysInLastMonth.Where(date => date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday);
            bool isRegularCustomer = weekdaysInLastMonth.All(date => purchaseDates.Any(purchaseDate => purchaseDate.Date == date));

            return isRegularCustomer;
        }

        return false;
    }

    private static async Task SaveOrder(Order order)
    {
        var directoryPath = ConstantValues.FilePath;
        var ordersFile = ConstantValues.OrdersPath;

        // Ensure the directory exists
        Directory.CreateDirectory(directoryPath);

        // Initialize allOrders either from the existing file or as a new instance
        AllOrders allOrders = File.Exists(ordersFile)
            ? JsonSerializer.Deserialize<AllOrders>(await File.ReadAllTextAsync(ordersFile)) ?? new AllOrders()
            : new AllOrders();

        // Add the new order to the list
        allOrders.OrdersList.Add(order);

        // Serialize the list to JSON and write it to the file
        string newJson = JsonSerializer.Serialize(allOrders);
        await File.WriteAllTextAsync(ordersFile, newJson);
    }
    private async Task FetchOrders()
    {
        var ordersFile = ConstantValues.OrdersPath;

        if (File.Exists(ordersFile))
        {
            try
            {
                string jsonFromFile = await File.ReadAllTextAsync(ordersFile);
                AllOrders? allOrders = JsonSerializer.Deserialize<AllOrders>(jsonFromFile);

                if (allOrders != null)
                {
                    _ordersList = allOrders.OrdersList;
                }
            }
            catch (Exception e)
            {
                // Handle exceptions here, such as logging or displaying an error message
                Console.WriteLine($"An error occurred while reading the file: {e.Message}");
            }
        }
    }

}

```