# OBA_320_4214

# Left-Center-Right (LCR)

This is the project repo for a small C# console prototype of the party game Left‑Center‑Right, built for Modul 320.

## What it does

- Lets you add players and auto-runs an LCR game round
- Shows the game state after each turn
- Simple CLI (with a tiny bit of decoration)

## Rules (short + link)

- Everyone starts with 3 chips. On your turn, roll up to 3 dice (max 3; fewer if you have fewer chips).
- Results: L = pass one chip left, C = put one chip in the center (pot), R = pass one chip right, dot = keep.
- If you have 0 chips, you skip rolling. Last player with any chips wins.
- Full rules: https://gamerules.com/rules/left-center-right/

## My notes (what went wrong/right)

- Indexing bugs: hit out-of-range issues with setting the current player and finding the player to the right/left. Fixed by carefully wrapping indices (modulo) and guarding edge cases.
- Changing turns: switching the current player caused weirdness. Using a temp variable during index updates stabilized it.
- Duplicate names: right now you can still add players with the same name. That’s on the list to fix.
- Looks: started ugly, added some light decoration so it’s easier to read.
