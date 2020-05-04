# Base Character Animations
All weapon animations must include all in the Animations section to allow smooth basic movement.
Additionally they are accessed in script with the parameters below.

# Animations
- RunningForwards
- RunningBackwards
- StrafeLeft
- StrafeRight
- Idle
- Hit
- Death

# Parameters
( [type]Keyword ) = parameter
{
  * State = Meaning
}
---
( [int]Vertical )
{
  -1 = Backwards
  0 = Idle
  1 = Forwards
}
---
( [int]Horizontal )
{
 * -1 = StrafeLeft
 * 0 = Idle
 * 1 = StrafeRight
}
---
( [trigger|bool]Hit )
{
  * true = player was hit
  * false = Not hit 
}
---
( [trigger|bool]Death )
{
  * true = player is dead
  * false = player is alive
}