using System;
using System.Collections.Generic;

namespace ECommerceCartSystem
{
    // 1. ABSTRACTION PILLAR

    // // Abstraction Example
    // Role: Yeh abstract class pure system ke products ke liye ek base blueprint hai.
    // Iska directly object nahi ban sakta, yeh sirf rules aur common data share karti hai.
    public abstract class Product
    {
        // Protected fields: Sirf yeh class aur isse inherit hone wali child classes inhe access kar sakti hain.
        protected int productId;
        protected string productName;
        protected double productPrice;
        protected int productStock;
        protected string productSku;

        // Constructor: Naye products ka base data memory mein reserve karne ke liye. mujhy object nahi banana pryega sabka.
        public Product(int id, string name, double price, int stock, string sku)
        {
            this.productId = id;
            this.productName = name;
            this.productPrice = price;
            this.productStock = stock;
            this.productSku = sku;
        }

        // Safe Data Layer Access via encapsulation concepts wrapped inside abstractraction.
        public int ProductId
        {
            get { return this.productId; }
        }

        public string ProductName
        {
            get { return this.productName; }
        }

        public double ProductPrice
        {
            get { return this.productPrice; }
        }

        public int ProductStock
        {
            get { return this.productStock; }
            set { this.productStock = value; }
        }

        public string ProductSku
        {
            get { return this.productSku; }
        }

        // Abstract Method: Iski implementation child classes khud apni logic se karengi.
        public abstract void DisplayDetails();

        // Virtual Method: Aik basic functional rule jo agar koi child class override karna chahe to kar sakti hai.
        public virtual void DisplayShortSummary()
        {
            Console.WriteLine("Prod ID: " + this.productId + " | " + this.productName + " | Price: " + this.productPrice);
        }
    }

    // // Abstraction Example (Interface)
    // Role: Payment processing channels ke darmiyan common contract bridge banaye ga
    // Har payment system class ko compulsory yeh structure implement karna hoga 
    public interface IPaymentProcessor
    {
        bool ValidatePaymentCredentials();
        bool ProcessPayment(double amount);
        void PrintReceipt(double finalAmount);
    }

    // 2. INHERITANCE PILLAR & 3. POLYMORPHISM PILLAR

    // // Inheritance And Polymorphism Example
    // Role: Electronics category ke items ko details ke sath manage karti hai.
    public class Electronics : Product
    {
        private string brandName;
        private int warrantyMonths;
        private double powerConsumption;

        public Electronics(int id, string name, double price, int stock, string sku, string brand, int warranty, double power)
            : base(id, name, price, stock, sku)
        {
            this.brandName = brand;
            this.warrantyMonths = warranty;
            this.powerConsumption = power;
        }

        public string BrandName { get { return this.brandName; } }
        public int WarrantyMonths { get { return this.warrantyMonths; } }
        public double PowerConsumption { get { return this.powerConsumption; } }

        // Polymorphism via Method Overriding
        public override void DisplayDetails()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine(" CATEGORY       : ELECTRONICS DEVICE");
            Console.WriteLine("==============================================");
            Console.WriteLine(" Product ID     : " + this.productId);
            Console.WriteLine(" Title Name     : " + this.productName);
            Console.WriteLine(" Price Rate     : Rs. " + this.productPrice);
            Console.WriteLine(" Current Stock  : " + this.productStock + " Units Left");
            Console.WriteLine(" System SKU     : " + this.productSku);
            Console.WriteLine(" Brand Track    : " + this.brandName);
            Console.WriteLine(" Warranty Scope : " + this.warrantyMonths + " Months Active");
            Console.WriteLine(" Power Scale    : " + this.powerConsumption + " Watts");
            Console.WriteLine("----------------------------------------------");
        }
    }

    // // Inheritance & Polymorphism Example
    // Role: Clothing items ka specific metadata control karne ke liye use hoti hai.
    public class Clothing : Product
    {
        private string itemSize;
        private string itemMaterial;
        private string genderType;

        public Clothing(int id, string name, double price, int stock, string sku, string size, string material, string gender)
            : base(id, name, price, stock, sku)
        {
            this.itemSize = size;
            this.itemMaterial = material;
            this.genderType = gender;
        }

        public string ItemSize { get { return this.itemSize; } }
        public string ItemMaterial { get { return this.itemMaterial; } }
        public string GenderType { get { return this.genderType; } }

        // Polymorphism via Method Overriding
        public override void DisplayDetails()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine(" CATEGORY       : CLOTHING APPAREL");
            Console.WriteLine("==============================================");
            Console.WriteLine(" Product ID     : " + this.productId);
            Console.WriteLine(" Title Name     : " + this.productName);
            Console.WriteLine(" Price Rate     : Rs. " + this.productPrice);
            Console.WriteLine(" Current Stock  : " + this.productStock + " Units Left");
            Console.WriteLine(" System SKU     : " + this.productSku);
            Console.WriteLine(" Available Size : " + this.itemSize);
            Console.WriteLine(" Fabric Core    : " + this.itemMaterial);
            Console.WriteLine(" Target Gender  : " + this.genderType);
            Console.WriteLine("----------------------------------------------");
        }
    }

    // // Inheritance & Polymorphism Example
    // Role: Grocery standard products aur unki expiry parameters handle karti hai.
    public class Groceries : Product
    {
        private string expiryDate;
        private double netWeight;
        private bool requiresRefrigeration;

        public Groceries(int id, string name, double price, int stock, string sku, string expiry, double weight, bool keepCold)
            : base(id, name, price, stock, sku)
        {
            this.expiryDate = expiry;
            this.netWeight = weight;
            this.requiresRefrigeration = keepCold;
        }

        public string ExpiryDate { get { return this.expiryDate; } }
        public double NetWeight { get { return this.netWeight; } }
        public bool RequiresRefrigeration { get { return this.requiresRefrigeration; } }

        // Polymorphism via Method Overriding
        public override void DisplayDetails()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine(" CATEGORY       : FRESH GROCERY ITEM");
            Console.WriteLine("==============================================");
            Console.WriteLine(" Product ID     : " + this.productId);
            Console.WriteLine(" Title Name     : " + this.productName);
            Console.WriteLine(" Price Rate     : Rs. " + this.productPrice);
            Console.WriteLine(" Current Stock  : " + this.productStock + " Units Left");
            Console.WriteLine(" System SKU     : " + this.productSku);
            Console.WriteLine(" Expiration Date: " + this.expiryDate);
            Console.WriteLine(" Net Mass Weight: " + this.netWeight + " KG");
            Console.WriteLine(" Cold Storage   : " + (this.requiresRefrigeration ? "Yes Required" : "No Regular"));
            Console.WriteLine("----------------------------------------------");
        }
    }

    // // Inheritance & Polymorphism Example
    // Role: Books and academic literature parameters track karti hai.
    public class Books : Product
    {
        private string authorName;
        private string bookIsbn;
        private string bookGenre;

        public Books(int id, string name, double price, int stock, string sku, string author, string isbn, string genre)
            : base(id, name, price, stock, sku)
        {
            this.authorName = author;
            this.bookIsbn = isbn;
            this.bookGenre = genre;
        }

        public string AuthorName { get { return this.authorName; } }
        public string BookIsbn { get { return this.bookIsbn; } }
        public string BookGenre { get { return this.bookGenre; } }

        // Polymorphism via Method Overriding
        public override void DisplayDetails()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine(" CATEGORY       : LITERATURE / BOOK");
            Console.WriteLine("==============================================");
            Console.WriteLine(" Product ID     : " + this.productId);
            Console.WriteLine(" Book Title     : " + this.productName);
            Console.WriteLine(" Price Rate     : Rs. " + this.productPrice);
            Console.WriteLine(" Current Stock  : " + this.productStock + " Units Left");
            Console.WriteLine(" System SKU     : " + this.productSku);
            Console.WriteLine(" Main Author    : " + this.authorName);
            Console.WriteLine(" International #: " + this.bookIsbn);
            Console.WriteLine(" Literature Type: " + this.bookGenre);
            Console.WriteLine("----------------------------------------------");
        }
    }

    // // Inheritance & Polymorphism Example
    // Role: Footwear products sizing and variant characteristics store karti hai.
    public class Footwear : Product
    {
        private int shoeSize;
        private string shoeColor;
        private string materialType;

        public Footwear(int id, string name, double price, int stock, string sku, int size, string color, string material)
            : base(id, name, price, stock, sku)
        {
            this.shoeSize = size;
            this.shoeColor = color;
            this.materialType = material;
        }

        public int ShoeSize { get { return this.shoeSize; } }
        public string ShoeColor { get { return this.shoeColor; } }
        public string MaterialType { get { return this.materialType; } }

        // Polymorphism via Method Overriding
        public override void DisplayDetails()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine(" CATEGORY       : FOOTWEAR WEARABLE");
            Console.WriteLine("==============================================");
            Console.WriteLine(" Product ID     : " + this.productId);
            Console.WriteLine(" Name Brand     : " + this.productName);
            Console.WriteLine(" Price Rate     : Rs. " + this.productPrice);
            Console.WriteLine(" Current Stock  : " + this.productStock + " Units Left");
            Console.WriteLine(" System SKU     : " + this.productSku);
            Console.WriteLine(" Euro Size Num  : " + this.shoeSize);
            Console.WriteLine(" Finish Color   : " + this.shoeColor);
            Console.WriteLine(" Build Texture  : " + this.materialType);
            Console.WriteLine("----------------------------------------------");
        }
    }

    // 4. ENCAPSULATION PILLAR

    // // Encapsulation Example
    // Role: Cart ke har item ki configuration aur product link data safe tareeqe se store kary gi 
    public class CartItem
    {
        private Product internalProduct;
        private int itemQuantity;
        private double mappedDiscount;

        public CartItem(Product product, int quantity)
        {
            this.internalProduct = product;
            this.itemQuantity = quantity;
            this.mappedDiscount = 0.0;
        }

        // Controlled Data Gateway
        public Product InternalProduct
        {
            get { return this.internalProduct; }
        }

        public int ItemQuantity
        {
            get { return this.itemQuantity; }
            set { this.itemQuantity = value; }
        }

        public double MappedDiscount
        {
            get { return this.mappedDiscount; }
            set { this.mappedDiscount = value; }
        }

        public double CalculateItemTotal()
        {
            double standardPrice = this.internalProduct.ProductPrice * this.itemQuantity;
            double reducedPrice = standardPrice - this.mappedDiscount;

            if (reducedPrice < 0)
            {
                return 0;
            }
            return reducedPrice;
        }

        public void ApplyBulkCoupon(double reductionAmount)
        {
            if (reductionAmount > 0)
            {
                this.mappedDiscount = reductionAmount;
            }
        }
    }

    // // Encapsulation Example
    // Role: Cart array list workflows ko completely modify aur safeguard karti hai input injection se.
    public class ShoppingCart
    {
        private List<CartItem> userItems;
        private string activeCouponCode;
        private double globalTaxRate;

        public ShoppingCart()
        {
            this.userItems = new List<CartItem>();
            this.activeCouponCode = "NONE";
            this.globalTaxRate = 0.05; // 5% Standard internal Tax
        }

        public List<CartItem> UserItems
        {
            get { return this.userItems; }
        }

        public string ActiveCouponCode
        {
            get { return this.activeCouponCode; }
            set { this.activeCouponCode = value; }
        }

        // Add Product functionality with multi-layer validation
        public bool AddItemToCart(Product targetProduct, int requestedQty)
        {
            if (targetProduct == null)
            {
                Console.WriteLine("[VALIDATION ERROR]: Targeted product allocation reference does not exist in context.");
                return false;
            }

            if (requestedQty <= 0)
            {
                Console.WriteLine("[VALIDATION ERROR]: Requested operation sequence rejected. Quantity must be greater than zero.");
                return false;
            }

            if (requestedQty > targetProduct.ProductStock)
            {
                Console.WriteLine("[STOCK ALERT]: Insufficient resource capacity. Available node volume: " + targetProduct.ProductStock);
                return false;
            }

            // Loop to check if element exists previously
            for (int indexValue = 0; indexValue < this.userItems.Count; indexValue++)
            {
                if (this.userItems[indexValue].InternalProduct.ProductId == targetProduct.ProductId)
                {
                    int compositeQty = this.userItems[indexValue].ItemQuantity + requestedQty;

                    if (compositeQty > targetProduct.ProductStock)
                    {
                        Console.WriteLine("[STOCK ALERT]: Collective quantity scale exceeds physical capacity ceilings.");
                        return false;
                    }

                    this.userItems[indexValue].ItemQuantity = compositeQty;
                    targetProduct.ProductStock = targetProduct.ProductStock - requestedQty;
                    return true;
                }
            }

            // Fresh Allocation Node
            CartItem cartNode = new CartItem(targetProduct, requestedQty);
            this.userItems.Add(cartNode);
            targetProduct.ProductStock = targetProduct.ProductStock - requestedQty;
            return true;
        }

        // Remove element with safely handling rollback memory loops
        public bool RemoveItemFromCart(int searchProductId)
        {
            int targetIndex = -1;

            for (int scanPointer = 0; scanPointer < this.userItems.Count; scanPointer++)
            {
                if (this.userItems[scanPointer].InternalProduct.ProductId == searchProductId)
                {
                    targetIndex = scanPointer;
                    break;
                }
            }

            if (targetIndex == -1)
            {
                Console.WriteLine("[CART ERROR]: Specified execution parameter target node not found inside active stack mapping.");
                return false;
            }

            // Inventory configuration counter reset
            CartItem referenceNode = this.userItems[targetIndex];
            referenceNode.InternalProduct.ProductStock = referenceNode.InternalProduct.ProductStock + referenceNode.ItemQuantity;

            this.userItems.RemoveAt(targetIndex);
            return true;
        }

        // Custom loop calculation pattern
        public double CalculateRawSubTotal()
        {
            double summationTotal = 0.0;

            for (int scanCounter = 0; scanCounter < this.userItems.Count; scanCounter++)
            {
                summationTotal = summationTotal + this.userItems[scanCounter].CalculateItemTotal();
            }

            return summationTotal;
        }

        public double CalculateTaxVolume()
        {
            double rawAmount = this.CalculateRawSubTotal();
            return rawAmount * this.globalTaxRate;
        }

        public double GetDiscountYield()
        {
            double baseSum = this.CalculateRawSubTotal();

            if (this.activeCouponCode == "DISCOUNT10" && baseSum >= 5000)
            {
                return baseSum * 0.10; // 10% Flat Discount structural system
            }
            else if (this.activeCouponCode == "SAVE500" && baseSum >= 10000)
            {
                return 500.00; // Fixed numeric discount node
            }

            return 0.0;
        }

        public double CalculateAbsoluteGrandTotal()
        {
            double runningSum = this.CalculateRawSubTotal();
            double computationalTax = this.CalculateTaxVolume();
            double systemReduction = this.GetDiscountYield();

            double finalOutputResult = (runningSum + computationalTax) - systemReduction;

            if (finalOutputResult < 0)
            {
                return 0.0;
            }
            return finalOutputResult;
        }

        // Text output matrix mapping layout design
        public void ViewCartContent()
        {
            Console.Clear();
            Console.WriteLine("=================================================================================");
            Console.WriteLine("                         GENERAL E-COMMERCE SHOPPING CART                        ");
            Console.WriteLine("=================================================================================");

            if (this.userItems.Count == 0)
            {
                Console.WriteLine("\n [STATUS LOG]: System cart structure is empty. No tracking elements mapped.");
                Console.WriteLine("=================================================================================");
                return;
            }

            Console.WriteLine("Node ID\t\tItem Name Description\t\tPrice Unit\tQty\tTotal Sum");
            Console.WriteLine("---------------------------------------------------------------------------------");

            for (int iterateTrack = 0; iterateTrack < this.userItems.Count; iterateTrack++)
            {
                CartItem trackedUnit = this.userItems[iterateTrack];
                string nameBuffer = trackedUnit.InternalProduct.ProductName;

                if (nameBuffer.Length > 18)
                {
                    nameBuffer = nameBuffer.Substring(0, 15) + "...";
                }
                else
                {
                    nameBuffer = nameBuffer.PadRight(18);
                }

                Console.WriteLine(trackedUnit.InternalProduct.ProductId + "\t\t" +
                                  nameBuffer + "\t\tRs. " +
                                  trackedUnit.InternalProduct.ProductPrice + "\t" +
                                  trackedUnit.ItemQuantity + "\tRs. " +
                                  trackedUnit.CalculateItemTotal());
            }

            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine(" System Gross SubTotal     : Rs. " + this.CalculateRawSubTotal());
            Console.WriteLine(" Applied Gov Tax Vector    : Rs. " + this.CalculateTaxVolume() + " (Fixed 5% Scaling)");
            Console.WriteLine(" Coupon Code System State  : " + this.activeCouponCode);
            Console.WriteLine(" Active Deduction Rebate   : Rs. " + this.GetDiscountYield());
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine(" TERMINAL CHARGE TOTAL     : Rs. " + this.CalculateAbsoluteGrandTotal());
            Console.WriteLine("=================================================================================");
        }

        public void EmptySystemCartCache()
        {
            this.userItems.Clear();
            this.activeCouponCode = "NONE";
        }
    }

    // INTERFACE & REALIZATION IMPLEMENTATION PIPELINE

    // // Interface Realization Example 
    // Role: Bank connection mechanics emulate karti hai credit authorization logic ke zariye.
    public class BankCreditCardProcessor : IPaymentProcessor
    {
        private string masterAccountHolder;
        private string identityCardSequence;
        private string verificationSecurityCode;

        public BankCreditCardProcessor(string clientName, string trackingCard, string localizedCvv)
        {
            this.masterAccountHolder = clientName;
            this.identityCardSequence = trackingCard;
            this.verificationSecurityCode = localizedCvv;
        }

        public bool ValidatePaymentCredentials()
        {
            Console.WriteLine(" [GATEWAY CONTROL]: Scanning authentication arrays for account parameters...");

            if (this.identityCardSequence.Length != 16)
            {
                Console.WriteLine(" [GATEWAY ERROR]: Structured credential sequence invalid. Length check failed.");
                return false;
            }

            if (this.verificationSecurityCode.Length != 3)
            {
                Console.WriteLine(" [GATEWAY ERROR]: Card Verification value structure mismatch.");
                return false;
            }

            Console.WriteLine(" [GATEWAY SUCCESS]: Structural link synchronization established safely.");
            return true;
        }

        public bool ProcessPayment(double allocationValue)
        {
            Console.WriteLine(" [GATEWAY LOG]: Activating connection secure handshake protocol via SSL channel...");
            Console.WriteLine(" [GATEWAY LOG]: Contacting financial node infrastructure core routing framework...");
            Console.WriteLine(" [TRANSACTION DEBIT]: Authorizing transmission amount value: Rs. " + allocationValue);
            Console.WriteLine(" [BANK SYSTEM]: Transaction ledger entries updated. Database balance subtracted.");
            return true;
        }

        public void PrintReceipt(double computationBalance)
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("         DIGITAL RECEIPT - CREDIT CARD NODE       ");
            Console.WriteLine("==================================================");
            Console.WriteLine(" Transaction Node Status: AUTHORIZED / SUCCESS");
            Console.WriteLine(" Card Account Primary   : XXXX-XXXX-XXXX-" + this.identityCardSequence.Substring(12));
            Console.WriteLine(" Client Target Reference: " + this.masterAccountHolder.ToUpper());
            Console.WriteLine(" Settlement Volume Net  : Rs. " + computationBalance);
            Console.WriteLine(" Server Time Sequence   : " + DateTime.Now.ToString());
            Console.WriteLine("==================================================");
        }
    }

    // // Interface Realization Example 
    // Role: Alternative telecom mobile payments framework register aur trace karti hai.
    public class DigitalWalletProcessor : IPaymentProcessor
    {
        private string registeredMobileToken;
        private string systemSecretPin;

        public DigitalWalletProcessor(string mobileNum, string secretPin)
        {
            this.registeredMobileToken = mobileNum;
            this.systemSecretPin = secretPin;
        }

        public bool ValidatePaymentCredentials()
        {
            Console.WriteLine(" [MOBILE WALLET LAYER]: Validating subscriber account structure status...");

            if (this.registeredMobileToken.Length != 11)
            {
                Console.WriteLine(" [WALLET ERROR]: Account token format mismatched. Must be 11 numeric digits.");
                return false;
            }

            if (this.systemSecretPin.Length != 4)
            {
                Console.WriteLine(" [WALLET ERROR]: Access security PIN code sequence contains system length violation.");
                return false;
            }

            return true;
        }

        public bool ProcessPayment(double debitSumAmount)
        {
            Console.WriteLine(" [MOBILE WALLET LAYER]: Blasting OTP challenge verification message code across cell lines...");
            Console.WriteLine(" [SYSTEM CHALLENGE]: Simulated customer validation sequence successfully triggered.");
            Console.WriteLine(" [SYSTEM DEBIT]: Finalizing wallet balance extraction mechanism routine...");
            Console.WriteLine(" [WALLET DEBIT SUCCESS]: Deducted ledger credit volume total: Rs. " + debitSumAmount);
            return true;
        }

        public void PrintReceipt(double finalDeductionScale)
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("         DIGITAL RECEIPT - WALLET CHANNEL         ");
            Console.WriteLine("==================================================");
            Console.WriteLine(" Channel Infrastructure : GSM Mobile Network Link");
            Console.WriteLine(" Registered Wallet Node : " + this.registeredMobileToken);
            Console.WriteLine(" Deducted Amount Status : Rs. " + finalDeductionScale);
            Console.WriteLine(" Transaction Reference #: EP-" + new Random().Next(100000, 999999));
            Console.WriteLine("==================================================");
        }
    }


    // Main Program 

    // // Main Structural Execution Class
    // Role: System initialization matrix run karti hai aur nested runtime options execute karti hai.
    public class Program
    {
        private static List<Product> centralizedInventory = new List<Product>();
        private static ShoppingCart transactionalCart = new ShoppingCart();

        public static void Main(string[] args)
        {
            // Seed operations
            PopulateSystemInventoryData();

            bool runtimeSystemFlag = true;

            while (runtimeSystemFlag == true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n********************************************************************************");
                    Console.WriteLine("*                 CENTRAL DATABASE FRAMEWORK: GENERAL CART SYSTEM             *");
                    Console.WriteLine("********************************************************************************");
                    Console.ResetColor();

                    Console.WriteLine("  [1] SYSTEM INVENTORY  -> View Complete Catalog Database Matrix");
                    Console.WriteLine("  [2] CLIENT CART STACK -> Add Specific Product Element To Active Cart Node");
                    Console.WriteLine("  [3] TRACK DATA VECTOR -> Inspect Current Shopping Cart Configuration");
                    Console.WriteLine("  [4] CACHE EVACUATION  -> Remove Isolated Item Reference From Active Cart");
                    Console.WriteLine("  [5] MARKETING ENGINE  -> Register Promotional Coupon Code Discount");
                    Console.WriteLine("  [6] PAYMENT GATEWAY   -> Proceed To Multi-Channel Secure Transaction Checkout");
                    Console.WriteLine("  [7] STRUCTURAL FLUSH  -> Clear Entire Cart Allocation Data State");
                    Console.WriteLine("  [8] SYSTEM DISCONNECT -> Terminate Application Lifecycle Thread Execution");
                    Console.WriteLine("********************************************************************************");
                    Console.Write(" >> Select Tactical Operation Target Code (1-8): ");

                    string selectionToken = Console.ReadLine();

                    switch (selectionToken)
                    {
                        case "1":
                            ExecuteInventoryListingRoutine();
                            break;

                        case "2":
                            ExecuteAddToCartWorkflowPipeline();
                            break;

                        case "3":
                            transactionalCart.ViewCartContent();
                            break;

                        case "4":
                            ExecuteRemoveFromCartPipeline();
                            break;

                        case "5":
                            ExecuteCouponEngineValidation();
                            break;

                        case "6":
                            ExecuteCheckoutPaymentGatewayEngine();
                            break;

                        case "7":
                            ExecuteResetCartCacheRoutine();
                            break;

                        case "8":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n [SHUTDOWN LOG]: Disconnecting active sessions thread. Flushing runtime buffer pools.");
                            Console.WriteLine(" [SHUTDOWN SUCCESS]: Core environment engine safely terminated. Safe journey ahead.");
                            Console.ResetColor();
                            runtimeSystemFlag = false;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n [CRITICAL ERROR]: User sequence exception. Option indicator key outside legal constraints.");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception generalEx)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n [EXCEPTION INTERCEPTED]: An unexpected error occurred: " + generalEx.Message);
                    Console.ResetColor();
                }

                // Intermediate break sequence mechanics
                if (runtimeSystemFlag == true)
                {
                    Console.WriteLine("\n >> Operation sequence complete. Press [ENTER] key to safely loop back to master menu...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        // Expanded Seed Database Allocation Module
        private static void PopulateSystemInventoryData()
        {
            try
            {
                // Category 1: Electronics Deployment Block
                centralizedInventory.Add(new Electronics(101, "OmniBook Laptop Pro", 145000.00, 8, "SKU-ELEC-773", "Generic Global", 12, 65.5));
                centralizedInventory.Add(new Electronics(102, "Galaxy Alpha Alpha", 92000.00, 14, "SKU-ELEC-441", "Brand Inc", 24, 25.0));
                centralizedInventory.Add(new Electronics(103, "Acoustic Pro Headset", 8500.00, 25, "SKU-ELEC-902", "Acoustic Corp", 6, 5.0));
                centralizedInventory.Add(new Electronics(104, "4K Smart Display Matrix", 115000.00, 5, "SKU-ELEC-118", "Display Corp", 18, 120.0));

                // Category 2: Clothing Apparel Deployment Block
                centralizedInventory.Add(new Clothing(201, "Slim-Fit Oxford Shirt", 2800.00, 30, "SKU-CLOT-112", "Medium", "Premium Cotton", "Unisex"));
                centralizedInventory.Add(new Clothing(202, "Vintage Denim Jeans", 4200.00, 18, "SKU-CLOT-509", "32 Waist", "Denim Weave", "Male"));
                centralizedInventory.Add(new Clothing(203, "Waterproof Sport Jacket", 8800.00, 10, "SKU-CLOT-883", "Large", "Polyester Blend", "Unisex"));

                // Category 3: Grocery Products Deployment Block
                centralizedInventory.Add(new Groceries(301, "Pure Organic Honey Jar", 1650.00, 50, "SKU-GROC-712", "12-12-2027", 1.0, false));
                centralizedInventory.Add(new Groceries(302, "Premium Basmati Rice", 450.00, 120, "SKU-GROC-341", "01-06-2028", 5.0, false));
                centralizedInventory.Add(new Groceries(303, "Salted Butter Pack Block", 680.00, 35, "SKU-GROC-892", "15-10-2026", 0.5, true));

                // Category 4: Books Literature Deployment Block
                centralizedInventory.Add(new Books(401, "C# Syntax Architecture", 3200.00, 15, "SKU-BOOK-009", "Dr. Alan Mercer", "978-3-16-148410-0", "Education"));
                centralizedInventory.Add(new Books(402, "Cyberwarfare Frontiers", 1850.00, 25, "SKU-BOOK-447", "S. J. Kincaid", "978-1-40-289462-1", "Security"));

                // Category 5: Footwear Deployment Block
                centralizedInventory.Add(new Footwear(501, "AirPace Athletic Runner", 12500.00, 14, "SKU-FOOT-992", 42, "Neon White", "Mesh Synthetic"));
                centralizedInventory.Add(new Footwear(502, "Classic Leather Loafers", 9500.00, 10, "SKU-FOOT-103", 41, "Dark Tan Brown", "Genuine Leather"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DATA SEED ERROR]: Failed to populate inventory: " + ex.Message);
            }
        }

        private static void ExecuteInventoryListingRoutine()
        {
            Console.Clear();
            Console.WriteLine("===============================================================================");
            Console.WriteLine("                     CENTRAL CATALOG SYSTEM INVENTORY LOGS                     ");
            Console.WriteLine("===============================================================================");

            for (int inventoryLoop = 0; inventoryLoop < centralizedInventory.Count; inventoryLoop++)
            {
                // Polymorphism Execution Point
                centralizedInventory[inventoryLoop].DisplayDetails();
                Console.WriteLine();
            }

            Console.WriteLine("===============================================================================");
            Console.WriteLine(" [SYSTEM STATUS]: Total allocated database entities scan rendered successfully.");
            Console.WriteLine("===============================================================================");
        }

        private static void ExecuteAddToCartWorkflowPipeline()
        {
            Console.Clear();
            Console.WriteLine("===============================================================================");
            Console.WriteLine("                       PRODUCT ACQUISITION CHANNEL INTAKE                      ");
            Console.WriteLine("===============================================================================");

            try
            {
                Console.Write(" >> Type Target Numeric Product ID: ");
                string targetRawId = Console.ReadLine();
                int validatedProductId = int.Parse(targetRawId);

                Product discoveredProductNode = null;

                for (int searchCounter = 0; searchCounter < centralizedInventory.Count; searchCounter++)
                {
                    if (centralizedInventory[searchCounter].ProductId == validatedProductId)
                    {
                        discoveredProductNode = centralizedInventory[searchCounter];
                        break;
                    }
                }

                if (discoveredProductNode == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" [SEARCH MISS]: Target identification parameter doesn't match inventory catalogs.");
                    Console.ResetColor();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" -> Item Selected: " + discoveredProductNode.ProductName + " | Base Unit Price: Rs. " + discoveredProductNode.ProductPrice);
                Console.ResetColor();
                Console.Write(" >> Input Demanded Volume/Quantity Units: ");

                string targetRawQty = Console.ReadLine();
                int validatedQty = int.Parse(targetRawQty);

                // Invoking protected class operations under encapsulation bounds
                bool actionOutcome = transactionalCart.AddItemToCart(discoveredProductNode, validatedQty);

                if (actionOutcome == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" [TRANSACTION SUCCESS]: Allocation trace map bound inside user cart stack nodes.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" [EXECUTION REJECTED]: Pipeline parameters verification failure.");
                    Console.ResetColor();
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [EXCEPTION CAUGHT]: Input parameter must be strictly numeric numbers!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [EXCEPTION CAUGHT]: Add To Cart operation failed: " + ex.Message);
                Console.ResetColor();
            }
        }

        private static void ExecuteRemoveFromCartPipeline()
        {
            Console.Clear();
            Console.WriteLine("===============================================================================");
            Console.WriteLine("                       CART ELEMENT ERASURE SUB-ROUTINE                        ");
            Console.WriteLine("===============================================================================");

            if (transactionalCart.UserItems.Count == 0)
            {
                Console.WriteLine(" [REJECTION]: Operation terminated. Target transactional cart cache contains zero items.");
                return;
            }

            try
            {
                Console.Write(" >> Input Target Product ID code for system elimination: ");
                string productInputBuffer = Console.ReadLine();
                int isolatedProductId = int.Parse(productInputBuffer);

                bool erasureExecutionResult = transactionalCart.RemoveItemFromCart(isolatedProductId);

                if (erasureExecutionResult == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" [CACHE CLEARED]: Memory node unlinked. Stock elements returned back into store catalogs.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" [PROCESS FAIL]: ID pattern does not interact with elements tracked inside user cart.");
                    Console.ResetColor();
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [EXCEPTION CAUGHT]: Product ID must be a valid integer!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [EXCEPTION CAUGHT]: Erase pipeline error: " + ex.Message);
                Console.ResetColor();
            }
        }

        private static void ExecuteCouponEngineValidation()
        {
            Console.Clear();
            Console.WriteLine("===============================================================================");
            Console.WriteLine("                       PROMOTIONAL DECENTRALIZED ENGINE                        ");
            Console.WriteLine("===============================================================================");
            Console.WriteLine(" Available Database Vouchers System List:");
            Console.WriteLine(" -> DISCOUNT10 : Grants 10% Flat Deductions on order values matching >= Rs. 5000");
            Console.WriteLine(" -> SAVE500    : Grants Rs. 500 Absolute Reduction on orders matching >= Rs. 10000");
            Console.WriteLine("-------------------------------------------------------------------------------");

            try
            {
                Console.Write(" >> Type Promotional Code: ");
                string rawCouponText = Console.ReadLine();

                if (rawCouponText == null)
                {
                    throw new ArgumentNullException("Coupon string reference cannot be null.");
                }

                string normalizedToken = rawCouponText.ToUpper().Trim();

                if (normalizedToken == "DISCOUNT10" || normalizedToken == "SAVE500")
                {
                    transactionalCart.ActiveCouponCode = normalizedToken;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" [COUPON VALID]: Code verification authorization successful. Vector status marked active.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" [COUPON INVALID]: Token verification failure. Input string not verified.");
                    transactionalCart.ActiveCouponCode = "NONE";
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [EXCEPTION CAUGHT]: Marketing Engine Encountered Error: " + ex.Message);
                Console.ResetColor();
            }
        }

        private static void ExecuteCheckoutPaymentGatewayEngine()
        {
            Console.Clear();
            Console.WriteLine("===============================================================================");
            Console.WriteLine("                       SECURE GATEWAY CHECKOUT TRANSACTION ROUTINE             ");
            Console.WriteLine("===============================================================================");

            try
            {
                double computedBillTotal = transactionalCart.CalculateAbsoluteGrandTotal();

                if (computedBillTotal <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" [CHECKOUT SUSPENDED]: Invoice balance totals equal zero. Processing pipeline canceled.");
                    Console.ResetColor();
                    return;
                }

                // Print checkout summaries clear
                Console.WriteLine(" Total Settlement Ledger Value Balance: Rs. " + computedBillTotal);
                Console.WriteLine(" Choose Interfacing Financial Transaction Core Protocol Endpoint Channel:");
                Console.WriteLine("   [1] VISA / MASTERCARD CREDIT GATEWAY INSTANCE");
                Console.WriteLine("   [2] DIGITAL SMART MOBILE WALLET PIPELINE");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.Write(" >> Choose Gateway Mode (1-2): ");

                string operationalModeKey = Console.ReadLine();
                IPaymentProcessor abstractPaymentInterfaceChannel = null;

                if (operationalModeKey == "1")
                {
                    Console.Write(" -> Enter Cardholder Name Label: ");
                    string clientName = Console.ReadLine();

                    Console.Write(" -> Enter 16-Digit Numerical Account Sequence: ");
                    string creditCardTrack = Console.ReadLine();

                    Console.Write(" -> Enter 3-Digit Card Verification Value (CVV): ");
                    string shortCvv = Console.ReadLine();

                    // Polymorphic interface binding instantiation
                    abstractPaymentInterfaceChannel = new BankCreditCardProcessor(clientName, creditCardTrack, shortCvv);
                }
                else if (operationalModeKey == "2")
                {
                    Console.Write(" -> Enter 11-Digit Subscriber Mobile Wallet Account Number: ");
                    string operationalCellNum = Console.ReadLine();

                    Console.Write(" -> Enter 4-Digit Private System Secret PIN Core: ");
                    string numericWalletPin = Console.ReadLine();

                    // Polymorphic interface binding instantiation
                    abstractPaymentInterfaceChannel = new DigitalWalletProcessor(operationalCellNum, numericWalletPin);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" [GATEWAY REJECTION]: Invalid channel indexing indicator key. Transaction safety abort.");
                    Console.ResetColor();
                    return;
                }

                // Polymorphic validation sequence executions
                bool operationalValidationFlag = abstractPaymentInterfaceChannel.ValidatePaymentCredentials();

                if (operationalValidationFlag == true)
                {
                    bool transactionTransferStatus = abstractPaymentInterfaceChannel.ProcessPayment(computedBillTotal);

                    if (transactionTransferStatus == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n**************************************************");
                        Console.WriteLine(" TRANSACTION PROCESSING ENGINE CONFIRMED SECURE ");
                        Console.WriteLine("**************************************************");
                        Console.ResetColor();

                        abstractPaymentInterfaceChannel.PrintReceipt(computedBillTotal);

                        // Transaction complete, wipe structural cache safely
                        transactionalCart.EmptySystemCartCache();
                    }
                    else
                    {
                        Console.WriteLine(" [SYSTEM REJECTION]: Core banking communication error. Settlement failed.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" [SYSTEM BLOCK]: Authentication credentials checking procedure failed. Pipeline rejected.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [EXCEPTION CAUGHT]: Payment gateway exception triggered: " + ex.Message);
                Console.ResetColor();
            }
        }

        private static void ExecuteResetCartCacheRoutine()
        {
            Console.Clear();
            Console.WriteLine("===============================================================================");
            Console.WriteLine("                       DESTRUCTIVE STRUCTURAL CART RESET                       ");
            Console.WriteLine("===============================================================================");

            try
            {
                Console.Write(" >> Warning: Are you sure you want to drop all data tracking nodes? (YES/NO): ");

                string verificationText = Console.ReadLine();

                if (verificationText != null && verificationText.ToUpper().Trim() == "YES")
                {
                    // Rollback item levels completely loop
                    for (int rollbackLoop = 0; rollbackLoop < transactionalCart.UserItems.Count; rollbackLoop++)
                    {
                        CartItem nodes = transactionalCart.UserItems[rollbackLoop];
                        nodes.InternalProduct.ProductStock = nodes.InternalProduct.ProductStock + nodes.ItemQuantity;
                    }

                    transactionalCart.EmptySystemCartCache();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" [SYSTEM CACHE FLUSHED]: Active vectors cleared out completely. Configuration zeroed.");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(" [SYSTEM LOG]: Destruction sequence aborted. Memory layers left unaltered.");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [EXCEPTION CAUGHT]: Cart reset error: " + ex.Message);
                Console.ResetColor();
            }
        }
    }
}

// ====================================================================================================
namespace ECommerceCartSystem
{
    // Extra infrastructure components for safety validation logic layers
    public class SystemDataValidator
    {
        private int structuralErrorCount;
        private int verificationCycleIndex;

        public SystemDataValidator()
        {
            this.structuralErrorCount = 0;
            this.verificationCycleIndex = 1;
        }

        public int StructuralErrorCount { get { return this.structuralErrorCount; } }
        public int VerificationCycleIndex { get { return this.verificationCycleIndex; } }

        public bool EvaluateNumericStringSafety(string processTargetInput)
        {
            try
            {
                if (processTargetInput == null)
                {
                    this.structuralErrorCount++;
                    return false;
                }
                if (processTargetInput.Trim().Length == 0)
                {
                    this.structuralErrorCount++;
                    return false;
                }
                for (int charPointer = 0; charPointer < processTargetInput.Length; charPointer++)
                {
                    char internalUnit = processTargetInput[charPointer];
                    if (internalUnit < '0' || internalUnit > '9')
                    {
                        this.structuralErrorCount++;
                        return false;
                    }
                }
                this.verificationCycleIndex++;
                return true;
            }
            catch (Exception)
            {
                this.structuralErrorCount++;
                return false;
            }
        }

        public bool AuditSystemPriceLimits(double priceEvaluationSubject)
        {
            if (priceEvaluationSubject < 0.0)
            {
                this.structuralErrorCount++;
                return false;
            }
            this.verificationCycleIndex++;
            return true;
        }

        public bool CheckIdentitySequenceLength(string targetIdentificationToken, int demandedBoundSize)
        {
            if (targetIdentificationToken == null)
            {
                this.structuralErrorCount++;
                return false;
            }
            if (targetIdentificationToken.Length == demandedBoundSize)
            {
                this.verificationCycleIndex++;
                return true;
            }
            this.structuralErrorCount++;
            return false;
        }

        public void RenderSystemReportSummaryLog()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                SYSTEM SECURITY VALIDATOR AUDIT RUN                   ");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine(" Evaluated Core Verification Cycles : " + this.verificationCycleIndex);
            Console.WriteLine(" Intercepted Operational Anomaly Logs: " + this.structuralErrorCount);
            Console.WriteLine(" Current Safety Execution Status     : SECURE COMPLIANT");
            Console.WriteLine("----------------------------------------------------------------------");
        }
    }

    public class SystemDisplayUtilities
    {
        private string headerPatternCharacter;
        private int screenPaddingWidth;

        public SystemDisplayUtilities()
        {
            this.headerPatternCharacter = "=";
            this.screenPaddingWidth = 80;
        }

        public string HeaderPatternCharacter
        {
            get { return this.headerPatternCharacter; }
            set { this.headerPatternCharacter = value; }
        }

        public int ScreenPaddingWidth
        {
            get { return this.screenPaddingWidth; }
            set { this.screenPaddingWidth = value; }
        }

        public void PrintApplicationBorderLine()
        {
            string buildingBuffer = "";
            for (int matrixBuilder = 0; matrixBuilder < this.screenPaddingWidth; matrixBuilder++)
            {
                buildingBuffer = buildingBuffer + this.headerPatternCharacter;
            }
            Console.WriteLine(buildingBuffer);
        }

        public void PrintCenteredApplicationMessage(string displayRawContent)
        {
            try
            {
                if (displayRawContent == null)
                {
                    return;
                }
                if (displayRawContent.Length >= this.screenPaddingWidth)
                {
                    Console.WriteLine(displayRawContent);
                    return;
                }
                int calculateSpaceSpan = (this.screenPaddingWidth - displayRawContent.Length) / 2;
                string dynamicPaddingString = "";
                for (int counterFiller = 0; counterFiller < calculateSpaceSpan; counterFiller++)
                {
                    dynamicPaddingString = dynamicPaddingString + " ";
                }
                Console.WriteLine(dynamicPaddingString + displayRawContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DISPLAY UTILITY ERROR]: " + ex.Message);
            }
        }

        public void DrawVisualSectionBreak()
        {
            Console.WriteLine();
            Console.WriteLine(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Console.WriteLine();
        }
    }

    public class SystemOperationalLogsManager
    {
        private List<string> architecturalLogsHistory;
        private int maximumStoredCapacity;

        public SystemOperationalLogsManager()
        {
            this.architecturalLogsHistory = new List<string>();
            this.maximumStoredCapacity = 100;
        }

        public List<string> ArchitecturalLogsHistory
        {
            get { return this.architecturalLogsHistory; }
        }

        public void PushNewExecutionLogNode(string runtimeMessageDetail)
        {
            try
            {
                if (runtimeMessageDetail == null)
                {
                    return;
                }
                string localizedTimestampFormat = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] ";
                string structuredCompositeMessage = localizedTimestampFormat + runtimeMessageDetail;

                if (this.architecturalLogsHistory.Count >= this.maximumStoredCapacity)
                {
                    this.architecturalLogsHistory.RemoveAt(0);
                }
                this.architecturalLogsHistory.Add(structuredCompositeMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[LOGGING ERROR]: " + ex.Message);
            }
        }

        public void RenderActiveLogsToConsoleOutput()
        {
            Console.Clear();
            Console.WriteLine("===============================================================================");
            Console.WriteLine("                SYSTEM LOGS INFRASTRUCTURE MANAGEMENT MATRIX                   ");
            Console.WriteLine("===============================================================================");
            if (this.architecturalLogsHistory.Count == 0)
            {
                Console.WriteLine(" [LOG ENGINE STATUS]: System logs buffer is empty. No history tracked.");
                Console.WriteLine("===============================================================================");
                return;
            }
            for (int logsLoopIndex = 0; logsLoopIndex < this.architecturalLogsHistory.Count; logsLoopIndex++)
            {
                Console.WriteLine(this.architecturalLogsHistory[logsLoopIndex]);
            }
            Console.WriteLine("===============================================================================");
        }
    }

    public class CustomerUserProfile
    {
        private int accountCustomerId;
        private string primaryCustomerName;
        private string electronicMailAddress;
        private string shippingPhysicalAddress;
        private double digitalLoyaltyPointsBalance;

        public CustomerUserProfile(int uid, string fullName, string email, string address)
        {
            this.accountCustomerId = uid;
            this.primaryCustomerName = fullName;
            this.electronicMailAddress = email;
            this.shippingPhysicalAddress = address;
            this.digitalLoyaltyPointsBalance = 0.0;
        }

        public int AccountCustomerId { get { return this.accountCustomerId; } }
        public string PrimaryCustomerName { get { return this.primaryCustomerName; } set { this.primaryCustomerName = value; } }
        public string ElectronicMailAddress { get { return this.electronicMailAddress; } set { this.electronicMailAddress = value; } }
        public string ShippingPhysicalAddress { get { return this.shippingPhysicalAddress; } set { this.shippingPhysicalAddress = value; } }
        public double DigitalLoyaltyPointsBalance { get { return this.digitalLoyaltyPointsBalance; } }

        public void CreditLoyaltyPointsReward(double basePurchaseAmountSpent)
        {
            if (basePurchaseAmountSpent > 0.0)
            {
                double computationalRewardPoints = basePurchaseAmountSpent * 0.01; // 1% calculation point matrix
                this.digitalLoyaltyPointsBalance = this.digitalLoyaltyPointsBalance + computationalRewardPoints;
                Console.WriteLine(" [REWARD SYSTEM]: Customer account credited with points: " + computationalRewardPoints);
            }
        }

        public void RenderCustomerProfileCard()
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("             CUSTOMER PROFILE ACCOUNT SUMMARY CARD         ");
            Console.WriteLine("==========================================================");
            Console.WriteLine(" Registered User ID   : ID-" + this.accountCustomerId);
            Console.WriteLine(" Customer Full Name   : " + this.primaryCustomerName);
            Console.WriteLine(" Communication E-Mail : " + this.electronicMailAddress);
            Console.WriteLine(" Physical Shipping Des: " + this.shippingPhysicalAddress);
            Console.WriteLine(" Active Loyalty Balance: " + this.digitalLoyaltyPointsBalance + " Points Available");
            Console.WriteLine("==========================================================");
        }
    }

    public class SystemInvoiceGenerator
    {
        private static int trackingInvoiceCounter = 50001;
        private int associatedInvoiceId;
        private CustomerUserProfile associatedUserProfile;
        private ShoppingCart compiledCartSource;
        private double calculatedTaxValue;
        private double calculatedDeductionsValue;
        private double absoluteBillingFinal;

        public SystemInvoiceGenerator(CustomerUserProfile targetedProfile, ShoppingCart sourceCart)
        {
            this.associatedInvoiceId = trackingInvoiceCounter;
            trackingInvoiceCounter++;
            this.associatedUserProfile = targetedProfile;
            this.compiledCartSource = sourceCart;
            this.calculatedTaxValue = sourceCart.CalculateTaxVolume();
            this.calculatedDeductionsValue = sourceCart.GetDiscountYield();
            this.absoluteBillingFinal = sourceCart.CalculateAbsoluteGrandTotal();
        }

        public int AssociatedInvoiceId { get { return this.associatedInvoiceId; } }
        public double AbsoluteBillingFinal { get { return this.absoluteBillingFinal; } }

        public void OutputInvoiceDocumentToConsolePrint()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("#################################################################################");
                Console.WriteLine("                       OFFICIAL INVOICE TRANSACTION RECORD                      ");
                Console.WriteLine("                       CORE REVENUE DISPATCH ENVIRONMENT                        ");
                Console.WriteLine("#################################################################################");
                Console.WriteLine(" Invoice Serial Code ID : INV-" + this.associatedInvoiceId);
                Console.WriteLine(" Generation Timestamp   : " + DateTime.Now.ToString("F"));
                Console.WriteLine("---------------------------------------------------------------------------------");
                if (this.associatedUserProfile != null)
                {
                    Console.WriteLine(" Billed Customer Client : " + this.associatedUserProfile.PrimaryCustomerName);
                    Console.WriteLine(" Deliver Destination    : " + this.associatedUserProfile.ShippingPhysicalAddress);
                }
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine(" Product Items Breakdown Ledger Summary Matrix:");
                Console.WriteLine("---------------------------------------------------------------------------------");

                for (int scanItemsIndex = 0; scanItemsIndex < this.compiledCartSource.UserItems.Count; scanItemsIndex++)
                {
                    CartItem targetItemNode = this.compiledCartSource.UserItems[scanItemsIndex];
                    Console.WriteLine(" -> " + targetItemNode.InternalProduct.ProductName.PadRight(25) +
                                      " x" + targetItemNode.ItemQuantity +
                                      " \tUnit: Rs. " + targetItemNode.InternalProduct.ProductPrice +
                                      " \tSub: Rs. " + targetItemNode.CalculateItemTotal());
                }

                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine(" Total Base Cost Valuation: Rs. " + this.compiledCartSource.CalculateRawSubTotal());
                Console.WriteLine(" Assessment Taxation Sum  : Rs. " + this.calculatedTaxValue);
                Console.WriteLine(" System Reductions Yield  : Rs. " + this.calculatedDeductionsValue);
                Console.WriteLine("=================================================================================");
                Console.WriteLine(" NET CHARGED OUTFLOW VALUE: Rs. " + this.absoluteBillingFinal);
                Console.WriteLine("#################################################################################");
                Console.WriteLine("             Thank you for trading alongside our e-commerce platforms.           ");
                Console.WriteLine("#################################################################################");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[INVOICE PRINT EXCEPTION]: " + ex.Message);
            }
        }
    }

    public class StoreInventoryAuditSystem
    {
        private List<Product> databaseReferencePointer;
        private string auditorNameIdentifier;

        public StoreInventoryAuditSystem(List<Product> masterInventoryLink, string auditorName)
        {
            this.databaseReferencePointer = masterInventoryLink;
            this.auditorNameIdentifier = auditorName;
        }

        public string AuditorNameIdentifier
        {
            get { return this.auditorNameIdentifier; }
            set { this.auditorNameIdentifier = value; }
        }

        public void TriggerFullInventoryLevelAudit()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("======================================================================");
                Console.WriteLine("             AUTOMATED STOCK AUDITING COMPLIANCE SUBSYSTEM            ");
                Console.WriteLine("======================================================================");
                Console.WriteLine(" Assigned Authorized Auditor Agent : " + this.auditorNameIdentifier);
                Console.WriteLine(" Verification Lifecycle Active Date: " + DateTime.Now.ToShortDateString());
                Console.WriteLine("----------------------------------------------------------------------");

                int operationalAlertsTriggered = 0;
                int normalOperationalStockNodes = 0;

                for (int loopIndexCounter = 0; loopIndexCounter < this.databaseReferencePointer.Count; loopIndexCounter++)
                {
                    Product inspectionSubjectNode = this.databaseReferencePointer[loopIndexCounter];

                    if (inspectionSubjectNode.ProductStock == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" [CRITICAL STOCK BREAK ALERT]: ID " + inspectionSubjectNode.ProductId + " (" + inspectionSubjectNode.ProductName + ") Stock completely depleted!");
                        Console.ResetColor();
                        operationalAlertsTriggered++;
                    }
                    else if (inspectionSubjectNode.ProductStock > 0 && inspectionSubjectNode.ProductStock <= 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(" [LOW STOCK WARNING MATRIX]: ID " + inspectionSubjectNode.ProductId + " (" + inspectionSubjectNode.ProductName + ") Low inventory: " + inspectionSubjectNode.ProductStock);
                        Console.ResetColor();
                        operationalAlertsTriggered++;
                    }
                    else
                    {
                        normalOperationalStockNodes++;
                    }
                }

                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine(" Stable Healthy Allocation Nodes : " + normalOperationalStockNodes);
                Console.WriteLine(" Replenishment Exception Requests: " + operationalAlertsTriggered);
                Console.WriteLine("======================================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[AUDIT EXCEPTION]: " + ex.Message);
            }
        }
    }

    public class ShippingLogisticsDispatcher
    {
        private string logisticsCarrierPartnerTitle;
        private double cargoBaseRateFactor;
        private int dispatchCounterTicks;

        public ShippingLogisticsDispatcher(string carrierTitle, double standardBaseRate)
        {
            this.logisticsCarrierPartnerTitle = carrierTitle;
            this.cargoBaseRateFactor = standardBaseRate;
            this.dispatchCounterTicks = 2001;
        }

        public string LogisticsCarrierPartnerTitle { get { return this.logisticsCarrierPartnerTitle; } }
        public double CargoBaseRateFactor { get { return this.cargoBaseRateFactor; } }

        public void TriggerManifestDispatchSequence(CustomerUserProfile targetReceiverProfile, ShoppingCart itemsContainerPayload)
        {
            this.dispatchCounterTicks++;
            Console.WriteLine("\n=========================================================================");
            Console.WriteLine("             LOGISTICS OUTBOUND DISPATCH MANIFEST GENERATOR               ");
            Console.WriteLine("=========================================================================");
            Console.WriteLine(" Waybill Shipment Reference ID : WB-" + this.dispatchCounterTicks);
            Console.WriteLine(" Transport Logistics Operator  : " + this.logisticsCarrierPartnerTitle);
            if (targetReceiverProfile != null)
            {
                Console.WriteLine(" Delivery Consignee Client Name: " + targetReceiverProfile.PrimaryCustomerName);
                Console.WriteLine(" Geographical Destination Route: " + targetReceiverProfile.ShippingPhysicalAddress);
            }
            Console.WriteLine(" Parcel Safety Loading Status  : MANIFEST LOCKED / ASSIGNED TO DEPOT");
            Console.WriteLine("=========================================================================");
        }
    }

    public class ECommerceSystemConfigManager
    {
        private string storeVersionIdentifier;
        private string environmentExecutionMode;

        public ECommerceSystemConfigManager()
        {
            this.storeVersionIdentifier = "v2.6.4-Enterprise";
            this.environmentExecutionMode = "PRODUCTION_STABLE";
        }

        public string StoreVersionIdentifier { get { return this.storeVersionIdentifier; } }
        public string EnvironmentExecutionMode { get { return this.environmentExecutionMode; } }

        public void DisplaySystemConfigurationSummaryPanel()
        {
            Console.WriteLine("=======================================================================");
            Console.WriteLine("               CORESITE DIAGNOSTICS ARCHITECTURE PANEL                ");
            Console.WriteLine("=======================================================================");
            Console.WriteLine(" Master Engine Microcode Build : " + this.storeVersionIdentifier);
            Console.WriteLine(" Core Pipeline Environment Mode: " + this.environmentExecutionMode);
            Console.WriteLine(" Framework Architecture Target : Microsoft .NET Console Base Environment");
            Console.WriteLine(" Memory Tracking Allocation    : Heap Engine Dynamic Garbage Pools");
            Console.WriteLine("=======================================================================");
        }
    }
}