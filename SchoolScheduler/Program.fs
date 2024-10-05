open System
open Giraffe
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging

let webApp =
    choose [
        route "/" >=> redirectTo true "/ping"
        route "/ping" >=> text "pong" ]

type Startup() =
    member _.ConfigureServices (services : IServiceCollection) =
        services.AddGiraffe() |> ignore

    member _.Configure (app : IApplicationBuilder)
                       (env : IHostEnvironment)
                       (loggerFactory : ILoggerFactory) =
        app.UseGiraffe webApp

[<EntryPoint>]
let main _ =
    Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(
            fun webHostBuilder ->
                webHostBuilder
                    .UseStartup<Startup>()
                    |> ignore)
        .Build()
        .Run()
    0