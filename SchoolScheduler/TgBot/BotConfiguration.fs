namespace SchoolScheduler.TgBot

[<CLIMutable>]
type BotConfiguration = {
    BotToken: string
    SecretToken: string
    Route: string
    Channel: string
    UseFakeApi: bool
}