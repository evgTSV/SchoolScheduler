open System
open SchoolScheduler.TgBot
open SchoolScheduler.Helpers
open Giraffe
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging

let botConfig = {
    BotToken = getEnv "BOT_TELEGRAM_TOKEN"
    SecretToken = getEnvOr "BOT_AUTH_TOKEN" "/bot"
    Route = getEnv "BOT_HOOK_ROUTE"
    Channel = getEnv "BOT_CHANNEL_URL"
    UseFakeApi = getEnvOr "USE_FAKE_TG_API" "false" |> bool.Parse
}    
let builder = WebApplication.CreateBuilder()
builder.Services.AddGiraffe() |> ignore

let app = builder.Build()

let webApp = choose [
    route "/" >=> text "Ok"
    route "/config" >=> json botConfig
]

app.UseGiraffe(webApp)

let server = app.RunAsync()

server.Wait()

()