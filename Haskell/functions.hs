-- -- A function definition and call
------ Example 1 ------
-- cube :: Int -> Int   -- parameter is an int, returns an int
-- cube num = num * num * num

-- main :: IO()
-- main = do
--     print(cube 3)


------ Example 2 ------
-- sayHi:: String -> String
-- sayHi name = "Hello " ++ name    -- You don't need do keyword because the function is one line

-- main = do
--     putStrLn(sayHi "Class")


------ Example 3 ------
-- travelToWork :: String -> IO () -- IO() for when you print stuff
-- travelToWork weather = do       -- Use the do keyword if you need there to be multiple lines in your function
--     if weather == "Sunny"       -- EVERY if statement in Haskell needs an else
--         then putStrLn "Walking to work"
--         else if weather == "Cloudy"
--                 then putStrLn "Biking to work"
--         else putStrLn "Driving to work"

-- main :: IO ()
-- main = do
--     travelToWork "Sunny"

------ Example 4 ------
-- travelToWork :: String -> Bool -> IO()  -- With multiple parameters
-- travelToWork weather isRaining = do
--     if weather == "Cloudy" && isRaining
--         then putStrLn "Driving to work"
--         else putStrLn "Walking to work"

-- main :: IO()
-- main = do
--     let isRaining = False
--     travelToWork "Sunny" isRaining


------ INPUT AND OUTPUT / IF STATEMENTS ------
-- main = do
--     putStrLn "Enter the first number and operator:"
--     firstStr <- getLine
--     operator <- getLine
--     putStrLn "Enter the 2nd number:"
--     secondStr <- getLine

--     let firstNumber = read firstStr :: Double   -- converts the strings into doubles
--     let secondNumber = read secondStr :: Double
    
--     if operator == "+"  -- Calculating the values
--         then print (firstNumber + secondNumber)
--     else if operator == "-"
--         then print (firstNumber - secondNumber)
--     else
--         putStrLn "Invalid operator"


------ CASE STATEMENTS (this code does not work) ------
main = do
    let grade = "F"
    case grade of
        "A" -> putStrLn "Great Work!"
        "B" -> putStrLn "Pretty Good!"
        "C" -> putStrLn "Alright!"
        "D" -> putStrLn "Not so great!"
        _ -> putStrLn "Sorry, you failed!"  -- The underscore is the default case
    

