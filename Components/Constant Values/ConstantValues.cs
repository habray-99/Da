﻿namespace Draft.Components.Constant_Values;

public class ConstantValues
{
    public const string FilePath = "D:\\Cafe";
    public static readonly string UserPath = Path.Combine(FilePath, "Users.json");
    public static readonly string CoffeePath = Path.Combine(FilePath, "Coffees.json");
    public static readonly string AddOnsPath = Path.Combine(FilePath, "AddOns.json");
    public static readonly string CustomerPath = Path.Combine(FilePath, "Customers.json");
    public static readonly string OrdersPath = Path.Combine(FilePath, "Orders.json");
    public static readonly string PdfsPath = Path.Combine(FilePath,"pdfs\\");
}