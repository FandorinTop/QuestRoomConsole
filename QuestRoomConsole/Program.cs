using Microsoft.EntityFrameworkCore;
using QuestRoom.BusinessLogic;
using QuestRoom.DataAccess;
using QuestRoom.DataAccess.UnitOfWork;
using QuestRoom.ViewModel.Common;
using QuestRoom.ViewModel.Discount.Request;

DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
var connectionString = "Server=(localdb)\\mssqllocaldb;Database=QuestRoom;Trusted_Connection=True;MultipleActiveResultSets=true;";
optionsBuilder.UseSqlServer(connectionString);
var options = optionsBuilder.Options;

using (ApplicationDbContext applicationDbContext = new ApplicationDbContext(options))
{
    await applicationDbContext.Database.EnsureCreatedAsync();
    var unitOfWork = new UnitOfWork(applicationDbContext);
    var discountService = new DiscountService(unitOfWork);

    //create set of discount
    if (!applicationDbContext.Discounts.Any())
    {
        await CreateDiscountSet(discountService);
    }

    var isHasFirstDiscount = await discountService.GetAll(0, 10, new List<FilterRequest>()
    {
        new FilterRequest()
        {
            FilterQuery = "First Handmade Discount",
            FilterColumn = "Name",
            IsPartFilter = false
        }
    }, new List<SortingRequest>());

    if (!isHasFirstDiscount.Data.Any())
    {
        var discountId = await discountService.Create(new CreateDiscountViewModel()
        {
            Name = "First Handmade Discount",
            Reduction = 50
        });
        
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"First Discount Added with id: '{discountId}'");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        var discount = isHasFirstDiscount.Data.FirstOrDefault();
        Console.WriteLine($"Result of request restricted by filter only for name: 'First Handmade Discount' Id: '{discount.Id}', Name: '{discount.Name}', Reduction: '{discount.Reduction}'%");
        Console.ResetColor();
    }
}

async Task CreateDiscountSet(DiscountService discountService)
{
    for (int i = 0; i < 50; i++)
    {
        await discountService.Create(new CreateDiscountViewModel()
        {
            Name = $"LoopDiscount: {i}",
            Reduction = i
        });
    }
}