-> tom_intro

=== tom_intro ===
TOM:
Come on… just a little more juice… Whoa, didn’t see you there! I guess I’m too used to being alone in these ruins. Name’s Tom. Used to be an electrician back in the day, before everything went to hell. You don’t look like the usual scavengers. What brings you to this godforsaken place?

+   ["Just passing through. What about you?"]
    -> explain_what_he_does

+   ["Looking for parts. This place still has some value."]
    -> explain_his_task

+   ["Trying to understand what happened here."]
    -> industrial_collapse

=== explain_what_he_does ===

TOM:
Yeah, same here. I’m a resource collector now. Spent years working with power systems, so I guess you could say I’m trying to patch things up… literally. This place is a goldmine, if you know what to look for. Lots of old tech just waiting to be revived. Of course, most of it’s busted beyond repair, but sometimes you get lucky.

*   ["Ever found anything really useful?"]
    -> tech_discovery

*   ["Sounds like you’ve been at this for a while."]
    -> time_in_ruins

=== explain_his_task ===

TOM:
Parts, huh? Well, you’re in the right place. This zone used to be the beating heart of the city’s industry. If it had wires, gears, or circuits, it passed through here. Of course, most of it’s rusted to hell now. But with a bit of patience, you can still find something worth salvaging. I’ve been picking through these ruins for years, trying to get something, anything, back online.

*   ["What are you working on now?"]
    -> current_project

*   ["What’s been the hardest part of all this?"]
    -> challenges

=== industrial_collapse ===

TOM:
Well, let me tell you… it didn’t happen overnight. This place used to be a powerhouse, churning out everything from electronics to heavy machinery. But that kind of production comes at a cost. The air here was so thick with pollution, you couldn’t see the sun most days. Factories didn’t care—they just kept running, burning through resources, poisoning the air and water. By the time the grid started failing, the damage was already done.

*   ["How did people survive after that?"]
    -> post_collapse_survival

*   ["So, it was just a matter of time before everything fell apart?"]
    -> inevitable_fall

=== tech_discovery ===

TOM:
Once or twice. Found an old generator that still had some life in it a few months back. Managed to get it running long enough to power up a few lights in the settlement. You’d be amazed how much of a difference a little light makes in a place like this. Of course, the real challenge is keeping it going. Everything here’s on its last legs. But every now and then, you hit pay dirt.

*   ["Sounds like you’re making progress."]
    -> progress_hopes

*   ["Must be tough, keeping things working."]
    -> challenges

=== time_in_ruins ===

TOM:
Feels like forever. I’ve been coming here since right after the collapse. At first, it was just about survival—scavenging for anything useful. But then I started thinking… maybe we could fix some of it. Maybe we could bring back a little bit of what we lost. That’s what keeps me going. The hope that maybe, just maybe, we can rebuild.

*   ["That’s a good way to think about it."]
    -> mission_briefing

*   ["It’s good to know someone’s still trying."]
    -> mission_briefing

=== current_project ===

TOM:
Right now? Trying to jury-rig an old circuit board into something functional. Might be able to use it to power up a smaller generator. It’s a long shot, but… That’s what this life is now—one long series of long shots.

*   ["Well, good luck with that."]
    -> mission_briefing

*   ["I hope it works out."]
    -> mission_briefing

=== challenges ===

TOM:
Biggest challenge? Besides the obvious lack of resources? It’s the decay. Everything’s breaking down faster than we can fix it. Parts are rusted, wires are corroded… even when you find something, it’s a race against time to get it working before it falls apart in your hands. But that’s the game now. You’ve got to be quicker than the rot.

*   ["Sounds like a tough job."]
    -> mission_briefing

*   ["Keep at it. We need people like you."]
    -> mission_briefing

=== post_collapse_survival ===

TOM:
Survival wasn’t pretty. When the power went out, so did the order. No more rules, no more safety nets. People did what they had to—some banded together, others… didn’t. Those first few years were chaos. But eventually, things settled down. Small communities formed, scavenging became the way of life. And here we are, still picking through the bones of the old world.

*   ["And trying to build something better?"]
    -> progress_hopes

*   ["It’s amazing anyone made it through."]
    -> mission_briefing

=== inevitable_fall ===

TOM:
Yeah, it was. With the way things were going… it was only a matter of time. We pushed the world too hard, took too much, and didn’t give anything back. Eventually, it all broke down. But that doesn’t mean we can’t learn from it. We’ve got a chance to do things differently now. To rebuild smarter, better.

*   ["Let’s make sure we do."]
    -> mission_briefing

*   ["I hope you’re right."]
    -> mission_briefing

=== progress_hopes ===

TOM:
Yeah. It’s slow, and it’s hard, but we’re making progress. Piece by piece, we’re putting things back together. It won’t be the same as before, but maybe that’s a good thing. We can’t afford to repeat the same mistakes. That’s why we’ve got to keep going, keep pushing forward. There’s still hope.

-> mission_briefing

=== mission_briefing ===

TOM:
Alright, enough talk. You’re here for a reason, right? If you’re looking for electrical parts, keep your eyes peeled. There’s still some good stuff buried under all this rubble. Good luck out there. 

+  [(Leave)]
      -> END

