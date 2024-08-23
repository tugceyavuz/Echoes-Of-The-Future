-> johnny_intro

=== johnny_intro ===

JOHNNY:
Well, now, look what the wind blew in. Name’s Johnny Miller. Not much left of the old farming days, but I reckon there’s still a bit of life in the soil yet. This here? It’s all that stands between us and starvation. Used to be, the land could feed a nation. Now, it’s a struggle just to grow a handful of greens.

+   [“What happened to the land?”]
    -> collapse_explanation

+   [“How do you keep anything growing in this mess?”]
    -> collapse_explanation

+   [“Can you spare some food?”]
    -> collapse_explanation

=== collapse_explanation ===

JOHNNY:
It wasn’t always like this. Before the Collapse, we had seasons, rain, soil rich with nutrients. But then came the pollution, the heatwaves, the storms. Bit by bit, the earth gave up. Crops failed, livestock died, and the land turned toxic. The soil’s poisoned now—most of it, anyway. Only a few things still grow, and those that do ain’t what they used to be. Mushrooms, a slice of bread if you’re lucky, and maybe a baguette on a good day. But most everything else? It’s as good as poison.

*   [“So what should I eat to stay alive?”]
    -> hunger_mechanics

*   [“And how do I know what’s safe?”]
    -> hunger_mechanics

*   [“What happens if I eat something that’s poisoned?”]
    -> hunger_mechanics

=== hunger_mechanics ===

JOHNNY:
Listen close, because this is important. Out here, hunger ain’t just a feeling—it’s a fight for survival. There’s three things you can count on to keep you going: mushrooms, a slice of bread, and if you’re real fortunate, a baguette. Those’ll fill your belly and keep you strong. And for drinkin’, clean water is your best bet. There’s still a few places you can find it, if you know where to look. And every now and then, you might stumble on a can of soda. It’s rare, but it’ll quench your thirst. Everything else out there? It’ll do more harm than good. The land’s sick, and anything it bears is likely to be poisoned. If you eat or drink the wrong thing, it’ll drain your health, maybe even kill you if you’re not careful.

*   [“Thanks for the advice. What’s next?”]
    -> offer_food

*   [“Is there anything you can do to help?”]
    -> offer_food

*   [“How did it get this bad?”]
    -> offer_food

=== offer_food ===

JOHNNY:
Tell you what—I’ve got a few mushrooms and a baguette I can spare. It ain’t much, but it’ll keep you on your feet for a while. You’ll need to keep an eye out for more as you go. And remember, what little grows here is all we’ve got, so take only what you need. I’m doing what I can to keep this place going, but it’s hard work. If you ever come across any seeds, or anything that might help, bring them my way. We’ve gotta think long-term if we’re going to make it.

*   [“I’ll keep that in mind. Thanks, Johnny.”]
    -> end_conversation

*   [“I’ll see what I can find.”]
    -> end_conversation

=== end_conversation ===

JOHNNY:
Good luck out there. And remember—this land might be dying, but as long as we’re still here, there’s hope for something to grow.
+ [(Leave)]
    -> END

-> END
