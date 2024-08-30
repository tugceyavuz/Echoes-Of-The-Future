-> industrial_zone_intro

=== industrial_zone_intro ===

MARCUS:
This place… this was once the beating heart of production. Factories, refineries, assembly lines—everything you could imagine came out of here. It kept the world running, but at a cost. The pollution… you could taste it in the air. The rivers ran black, the skies were gray, and the people… well, they didn’t last long.

+   [(Continue)]
    -> industrial_zone

=== industrial_zone ===

MARCUS:
The worst part is, we all knew what was happening. But no one wanted to stop. Profits were more important than the planet, more important than the people. And when the collapse came, this place was one of the first to fall. The machines stopped, the workers fled, and it all went silent. What’s left now… is just a ghost of what it used to be.

+   ["It's hard to believe people lived like this."]
    -> reflect_on_past

+   ["It must have been terrible. How did people survive?"]
    -> survival_in_industrial_zone

+   ["We’re close to the end now. What’s our plan?"]
    -> explain_mission_industrial

=== reflect_on_past ===

MARCUS:
Yeah, it’s hard to wrap your head around it. People got used to the filth, the sickness, the constant hum of machines. They didn’t realize what they were giving up until it was too late. By then, the damage was done, and there was no going back. But we’re here to make sure that what’s left of the world doesn’t end up the same way. We’ve got one last job to do.

*   ["Right. Let’s make it count."]
    -> explain_mission_industrial

*   ["I’m with you. What’s our next move?"]
    -> explain_mission_industrial

=== survival_in_industrial_zone ===

MARCUS:
Survival wasn’t easy here. The people who worked in these factories didn’t have much choice. They took what little they could get—a paycheck, a place to live, even if it meant breathing in poison every day. When the collapse happened, those who could escape did. The rest… well, most didn’t make it. We’ve come this far. Let’s make sure their sacrifices weren’t in vain.

*   ["I won’t let them down. What do we need to do?"]
    -> explain_mission_industrial

*   ["Let’s finish what we started."]
    -> explain_mission_industrial

=== explain_mission_industrial ===

MARCUS:
This is it—the final piece of the puzzle. Somewhere in this mess is the last computer we need to get online. Just like before, we’ll need to find the hardware piece that fits. But remember, you only get one shot. Choose carefully, because once it’s in place, there’s no going back. Search everywhere. These old factories might be falling apart, but they’re full of nooks and crannies where the part could be hiding.

+   ["Got it. I’ll be careful and thorough."]
    -> prepare_for_search

+   ["No mistakes this time. Let’s find that piece."]
    -> prepare_for_search

+   ["We’re almost there. Let’s do this."]
    -> prepare_for_search

=== prepare_for_search ===

MARCUS:
Alright. This is the final stretch. Once we get this computer up and running, the power station should come online. Let’s make it happen.

+   [(Leave)]
     -> END

