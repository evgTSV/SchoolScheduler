module SchoolScheduler.Helpers

open System

let getEnv name =
    let value = Environment.GetEnvironmentVariable(name)
    if value = null then
        raise (ArgumentException $"Required environment variable $s{name} not founded")
    else
        value
        
let tryGetEnv name =
    let value = Environment.GetEnvironmentVariable(name)
    if value = null then
        None
    else
        Some value
        
let getEnvOr name otherwise =
    let value = Environment.GetEnvironmentVariable(name)
    if value = null then
        otherwise
    else
        value