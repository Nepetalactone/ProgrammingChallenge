printfn "Enter temperature type and temperature"
let input = System.Console.ReadLine().Split[|' '|]
let temperatureType = input.[0]
let temperature = System.Double.Parse(input.[1])

match temperatureType, temperature with
| "celsius", _ -> printfn "Celsius\tKelvin\tFahrenheit\n%A\t%A\t%A" temperature (temperature + 273.15)  ((9.0/5.0) * temperature + 32.0)
| "kelvin", _ -> printfn "Celsius\tKelvin\tFahrenheit\n%A\t%A\t%A" (temperature - 273.15) temperature ((temperature - 273.15) * 1.8 + 32.0)
| "fahrenheit", _ -> printfn "Celsius\tKelvin\tFahrenheit\n%A\t%A\t%A" ((temperature - 32.0) * 5.0 / 9.0) ((temperature - 32.0) * 5.0 / 9.0 + 273.15) temperature
| _, _ -> ()

System.Console.ReadKey() |> ignore