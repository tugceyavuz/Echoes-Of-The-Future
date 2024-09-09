-> forest_path_intro

=== forest_path_intro ===

MARCUS:
Would you look at that… I never thought I’d see this place like this again. The last time I was here, everything was dead. The trees were blackened, the ground cracked and lifeless. It was like the world had given up. But now… there’s life here. It’s like nature’s finally pushing back, reclaiming what was lost. I can’t say I expected to see this much green again in my lifetime. Maybe there’s hope after all.

+   ["I’ve never seen anything like this. What happened here?"]
    -> explain_past_forest

+   ["It’s beautiful… Hard to believe it was ever dead."]
    -> reflect_on_recovery

+   ["Glad to see something positive. What’s our plan here?"]
    -> explain_mission_forest

=== explain_past_forest ===

MARCUS:
After the fall, this place was hit hard. Pollution, wildfires, and the collapse of ecosystems turned it into a wasteland. No birds, no insects, just silence and death. I used to walk these paths when I was younger, back when it was alive with wildlife. Seeing it like that, it felt like losing a part of myself. 

+   [(Continue)]
    -> explain_past_forest_cont
    
=== explain_past_forest_cont ===
MARCUS:
But now… maybe we didn’t lose everything. Nature’s got a way of healing, given time. And seeing this… it reminds me that we’ve got to keep pushing forward. There’s still something worth fighting for.

*   ["I agree. Let’s make sure we do our part."]
    -> explain_mission_forest

*   ["It’s good to hear there’s hope. What’s our next move?"]
    -> explain_mission_forest

=== reflect_on_recovery ===

MARCUS:
Yeah, it’s a sight, isn’t it? Sometimes it feels like the world’s determined to bounce back, no matter how much we’ve thrown at it. It’s a reminder that maybe, just maybe, things can get better if we work for it. But it’s a fragile thing. We can’t take it for granted. Alright, enough reminiscing. We’ve got a job to do here.

*   ["Right. Let’s get to work."]
    -> explain_mission_forest

*   ["I’m with you. What do we need to do?"]
    -> explain_mission_forest

=== explain_mission_forest ===

MARCUS:
Same deal as before. Somewhere in this forest, there’s a piece of hardware we need. It could be tucked away in a broken-down cabin, buried under debris, or hidden in plain sight. You’ll need to search carefully. And remember—once you find it, you’ve only got one shot to place it in the right spot. The computer won’t do a thing until the hardware’s installed correctly. So, take your time, look for the right connection, and make sure it’s a good fit.

+   ["Got it. Let's start searching."]
    -> encourage_search_forest

+   ["I’ll be careful. We can’t afford to mess this up."]
    -> encourage_search_forest

+   ["Let’s find that piece and get out of here."]
    -> encourage_search_forest

=== encourage_search_forest ===

MARCUS:
Once we’ve got that piece, we’ll find the computer and get it running. I will wait for you outside the Forest. And hey… maybe, once this is all over, we’ll have more places like this to walk through again. Let’s make sure of it.

+ [(Leave)]
    -> END
