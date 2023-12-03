using Microsoft.Extensions.DependencyInjection;
using WhatWhere;
using WhatWhere.DataProviders;
using WhatWhere.Entities;
using WhatWhere.Repositories;
using WhatWhere.Services;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<AGD>, SqlRepository<AGD>>();
services.AddSingleton<IRepository<FoodProduct>, SqlRepository<FoodProduct>>();
services.AddSingleton<IRepository<KitchenAccessory>, SqlRepository<KitchenAccessory>>();
services.AddSingleton<IRepository<AGD>, RepositoryToFileJson<AGD>>();
services.AddSingleton<IRepository<FoodProduct>, RepositoryToFileJson<FoodProduct>>();
services.AddSingleton<IRepository<KitchenAccessory>, RepositoryToFileJson<KitchenAccessory>>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventHandlerServices, EventHandlerServices>();
services.AddSingleton<IAdditionalOption, AdditionalOption>();
services.AddSingleton<IFoodProductProvider, FoodProductProvider>();


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>()!;
app.Run();