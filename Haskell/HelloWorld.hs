-- Method 1:
-- main :: IO()
-- main = putStrLn "Hello World!"

-- Method 2
-- main = do
--     putStrLn "Hello World!"

-- Method 3
-- main  = do
--     putStrLn "|    |    |    |    |    |    |    |    |"
--     putStrLn "|    |    |    |    |    |    |    |    |"
--     putStrLn "|    |    |    |    |    |    |    |    |"
--     print 36    -- Use print to print numbers, putStrLn to print strings
-- x :: Integer
-- x = 1 + 2

-- name :: String
-- name = "Dudley"

-- numOfGifts :: Integer
-- numOfGifts = 36

-- dudlyGpa :: Double
-- dudlyGpa = 3.6

-- myLetter :: Char
-- myLetter = 'A'  -- <-This must be in single quotes

-- main = do
--     putStrLn "What is your Name? "
--     name <- getLine
--     putStrLn (name ++ " received " ++ show numOfGifts ++ " gifts for his birthday") -- Show is used to convert a given value into a string for printing
--     print myLetter
--     print dudlyGpa



-- Lists
score :: [Int]
score = [0, 1, 2, 3, 4, 5]

main = do
    print(score !! 2)   -- This will print the third element of the list just like in C if you were to do score[2]
    print(last score)
    print(head score)
    print(init score)