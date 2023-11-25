using Microsoft.Extensions.DependencyInjection;
using WhatWhere;
using WhatWhere.Entities;
using WhatWhere.Repositories;
using WhatWhere.Services;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<AGD>, SqlRepository<AGD>>();
services.AddSingleton<IRepository<Groceries>, SqlRepository<Groceries>>();
services.AddSingleton<IRepository<KitchenAccessories>, SqlRepository<KitchenAccessories>>();
services.AddSingleton<IRepository<AGD>, RepositoryToFileJson<AGD>>();
services.AddSingleton<IRepository<Groceries>, RepositoryToFileJson<Groceries>>();
services.AddSingleton<IRepository<KitchenAccessories>, RepositoryToFileJson<KitchenAccessories>>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventHandlerServices, EventHandlerServices>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>()!;
app.Run();