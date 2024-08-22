-> dr_chambers_quest

=== dr_chambers_quest ===

DR. CHAMBERS:
Welcome to my clinic, or what's left of it. I suppose you’re new here, so let me fill you in. This world—it wasn’t always like this. It used to be… better. Cleaner. Climate change, pollution… It all spiraled out of control. The air, the water—it all turned toxic. People got sick, crops failed, and society collapsed. Now, we’re just trying to survive in the ruins of what was once a thriving world.

+   [(continue)]
    -> dr_chambers_quest_cont

=== dr_chambers_quest_cont ===

DR. CHAMBERS:
Welcome to my clinic, or what's left of it. I suppose you’re new here, so let me fill you in. This world—it wasn’t always like this. It used to be… better. Cleaner. Climate change, pollution… It all spiraled out of control. Governments tried to fix things, but they were too late. The air, the water—it all turned toxic. People got sick, crops failed, and society collapsed. Now, we’re just trying to survive in the ruins of what was once a thriving world.
Which brings me to why I need your help. My supplies are running low, and the only way to keep treating people is with your help. Specifically, I need mushrooms. They’ve adapted to this new world, and I use them in my medicines.

+   [“What kind of medicine are we talking about?”]
    -> explain_medicine

+   [“Mushrooms? Where can I find them?”]
    -> explain_mushrooms

+   [“Why should I help you?”]
    -> why_help

=== explain_medicine ===
DR. CHAMBERS:
This is one of the few things standing between life and death for a lot of people here. It helps with infections, fever, and even some of the nastier effects of the polluted air. If you bring me 10 mushrooms, I’ll give you 2 doses. And trust me, you’re going to need them out there.

*   [“Alright, 10 mushrooms for 2 medicines. I’m in.”]
    -> accept_quest

*   [“Why are mushrooms so important?”]
    -> explain_mushrooms

*   [“Is there any other way to get medicine?”]
    -> no_other_way

=== explain_mushrooms ===
DR. CHAMBERS:
Mushrooms are one of the few things that still grow in this mess of a world. They’ve adapted to the pollution, and some of them have properties that make them useful for medicine. You’ll find them in damp, shaded areas—caves, under rocks, that sort of thing. Or anywhere to be honest. Always look around.

*   [“Got it. I’ll start looking.”]
    -> accept_quest

*   [“How do I know which ones to pick?”]
    -> picking_mushrooms

*   [“Why do you need so many of them?”]
    -> why_help

=== picking_mushrooms ===
DR. CHAMBERS:
Look for the ones with orange caps and white stems. Avoid the ones with bright colors; those are more likely to be toxic.

*   [“Understood. I’ll find the right ones.”]
    -> accept_quest

*   [“What happens if I pick the wrong ones?”]
    -> no_other_way

=== no_other_way ===
DR. CHAMBERS:
There’s no other way to get medicine here, at least not if you are extremely lucky, then maybe you can find some in shelfs. 
The few people who know how to make it keep to themselves, and I’m one of the few who’ll share. Help me out, and I’ll help you. That’s the deal.

*   [“Alright, I’ll bring you the mushrooms.”]
    -> accept_quest

=== why_help ===
DR. CHAMBERS:
Because out there, you’ll need every bit of help you can get. This world doesn’t care about us, but we can still care about each other. And in return, I’ll make sure you’re stocked up on medicine. Deal?

*   [“Alright, deal. I’ll get those mushrooms.”]
    -> accept_quest


=== accept_quest ===
DR. CHAMBERS:
Good. Bring me 10 mushrooms, and I’ll give you 2 doses of medicine. Don’t take too long—people are counting on me, and soon, they’ll be counting on you too.
Also, whatever extra food or drink you find, just make sure to eat and drink them. Otherwise you might die from starvation or thirst.

+ ["Thank you for the advice, I will be back"]
    ->END
    
-> END

