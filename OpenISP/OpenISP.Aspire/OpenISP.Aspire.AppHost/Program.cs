var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<Projects.OpenISP_Web>("openisp-web");
builder.Build().Run();
