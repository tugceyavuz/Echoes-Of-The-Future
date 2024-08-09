-> level_1_start

=== level_1_start ===

MARCUS:
You're just in time. We've been working hard to keep this place running, but as you can see, the world outside these walls is unforgiving. We’re low on resources, and the power source that keeps this settlement safe is failing. I could use your help.

+   [“Where am I? How did I get here?”]
    -> explain_environment

+   [“What do you mean? I don’t understand any of this.”]
    -> explain_era

+   [“I need to know more before I can help.”]
    -> detailed_explanation

=== explain_environment ===
MARCUS:
 My name’s Marcus King. You’re in a small settlement, one of the few places left where the air’s still mostly clean. Climate change and environmental collapse have ravaged much of what we once knew. We're trying to survive and rebuild, but we need to fix some critical systems first. As for how you got here… We found you not far from the perimeter, unconscious.

*   [“What systems are you talking about?”]
    -> power_source_task

*   [“How can I help with this?”]
    -> power_source_task

*   [“This is a lot to take in. What should I do first?”]
    -> initial_task

=== explain_era ===
MARCUS:
You’re in one of the last safe zones, a settlement built to withstand what’s left of this world. Decades of ignoring the warnings, pushing the planet past its limits. By the time people realized what was happening, it was too late. We fought wars over resources, and eventually, society crumbled. Now, we’re left picking up the pieces.

*   [“What exactly needs fixing?”]
    -> power_source_task

*   [“I don’t know if I can do this.”]
    -> reassure_player

*   [“What should I focus on?”]
    -> initial_task

=== detailed_explanation ===
MARCUS:
Alright, here’s the deal: we have a power source connected to several computers across different areas. To restore power, you’ll need to repair these computers. It’s a task that requires some exploration and understanding of how things work now. You’ll get the hang of it. And I will accompany you in this task so don't worry.

*   [“How do I start with these repairs?”]
    -> power_source_task

*   [“What should I do while exploring?”]
    -> initial_task

*   [“I’m feeling overwhelmed. Any advice?”]
    -> reassure_player

=== power_source_task ===
MARCUS:
Our main power source is down, which affects several computers scattered around. You need to visit these computers, check their status, and repair them as needed. Restoring power to all of them will help us regain some functionality.

*   [“Where are these computers located?”]
    -> computer_locations

*   [“How do I repair them?”]
    -> repair_instructions

*   [“Alright, I’ll do my best.”]
    -> explore_and_gather

=== computer_locations ===
MARCUS:
You’ll find these computers in various locations: in the ruined city, outside the city in the wildness and the last one is in the Industrial zone. Each area might have its own challenges, so stay alert. I will explain the enviroment before we go in so don't worry.

*   [“Got it. Anything else I should know?”]
    -> repair_instructions

*   [“I’ll start with the library. Thanks for the info.”]
    -> explore_and_gather

*   [“Where do I get more information if I need help?”]
    -> detailed_explanation

=== repair_instructions ===
MARCUS:
Repairing the computers involves finding broken components and replacing them. Use the informations around the place to understand what is needed. Each computer has its own set of problems, so take your time to diagnose and fix them.

*   [“I’ll need to gather some tools first.”]
    -> gather_tools

*   [“I’m ready to start fixing.”]
    -> explore_and_gather

*   [“What if I run into trouble?”]
    -> reassure_player

=== gather_tools ===
MARCUS:
You might find some tools around the settlement. Check the infirmary or ask around. People here are usually helpful if you explain what you need.

*   [“Thanks, Marcus. I’ll get started.”]
    -> explore_and_gather

*   [“I’m not sure where to look.”]
    -> detailed_explanation

=== reassure_player ===
MARCUS:
Don’t worry too much. You’ll pick things up as you go. We’re all in this together. Just focus on one task at a time, and don’t hesitate to ask for help if you need it.

*   [“Okay, I’ll do my best.”]
    -> explore_and_gather

*   [“Thanks for the encouragement.”]
    -> explore_and_gather

=== initial_task ===
MARCUS:
Start by exploring the settlement. Talk to people to gather information and supplies. You’ll need food and drink to stay in good shape. Once you’re prepared, head through the border doors to the west. I’ll meet you outside.

*   [“I’ll explore and gather what I need.”]
    -> explore_and_gather

*   [“Where should I look for food and drink?”]
    -> food_and_drink

*   [“I’m ready to head out now.”]
    -> exit_now

=== food_and_drink ===
MARCUS:
You can find food and drink around the settlement. Also look around, there might be some food anywhere, hidden even. People might also have some supplies to spare. Just ask around and make sure you’re well-prepared.

*   [“Thanks, Marcus. I’ll find what I need.”]
    -> explore_and_gather

*   [“I don’t know where to start looking.”]
    -> explore_and_gather

=== exit_now ===
MARCUS:
Alright, be careful out there. I’ll see you outside the border doors.

-> END

=== explore_and_gather ===
MARCUS:
Good luck. Remember, you need to gather supplies before heading out. Once you’re ready, go through the west border doors, and I’ll meet you outside.

-> END
