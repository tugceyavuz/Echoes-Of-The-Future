-> lily_intro

=== lily_intro ===

LILY:
Hi! My name’s Lily. What’s yours? You look different from the others around here. Where did you come from?

+   [“I’m from... a long time ago, before all this happened.”]
    -> ask_about_past

+   [“I’ve been traveling for a while. What’s this place like?”]
    -> ask_about_present

+   [“Just trying to get by, like everyone else.”]
    -> ask_about_present

=== ask_about_present ===

LILY:
This place? It’s all I’ve ever known. They say there used to be tall buildings, trees everywhere, and even animals that weren’t dangerous. But now it’s just... this. Everything’s broken, and people are always looking for food and water. Sometimes I find mushrooms, or a slice of bread, but that’s about it. They told me there used to be more, but I can’t even imagine it.

*   [“It wasn’t always like this. Things used to be different.”]
    -> ask_about_past

*   [“How do you find enough to eat?”]
    -> explain_hunger_mechanics

*   [“Do you ever wonder what it was really like before?”]
    -> ask_about_past

=== ask_about_past ===

LILY:
You really remember what it was like before? What was it like? Did people really have enough food to eat every day? And what about the sky—was it really blue?

*   [“Yes, people had enough food, and the sky was blue. It was a different world.”]
    -> share_memories

*   [“Things were better in some ways, but we didn’t take care of the world like we should have.”]
    -> share_memories

*   [“It was nice, but we made mistakes. That’s why things are like this now.”]
    -> share_memories

=== share_memories ===

LILY:
Wow... I wish I could’ve seen it. Sometimes, I try to imagine what it was like, but it’s hard. Everything here is so... gray. Do you think it could ever be like that again? Maybe if we all work together, we could fix things?

*   [“Maybe. It’ll take a lot of work, but I believe it’s possible.”]
    -> explain_hunger_mechanics

*   [“I’m not sure. It might be too late for that.”]
    -> explain_hunger_mechanics

*   [“We can try, Lily. That’s all we can do.”]
    -> explain_hunger_mechanics

=== explain_hunger_mechanics ===

LILY:
Yeah, that’s what the others say too. For now, we just have to find what we can. The adults tell me not to eat anything but mushrooms, bread, or if I’m really lucky, a baguette. They say everything else is dangerous, like it’ll make you sick or worse. I don’t really get it, but I listen. Sometimes, I find a can of soda or some clean water, and that’s a good day. They say that’s all safe to drink, but everything else... no way.

*   [“That’s good advice, Lily. Stick to what’s safe.”]
    -> end_conversation

*   [“It’s a hard way to live, but you’re doing well.”]
    -> end_conversation

*   [“Just be careful. This world is dangerous.”]
    -> end_conversation

=== end_conversation ===

LILY:
Thanks for talking with me. I like hearing about the way things used to be, even if I can’t really imagine it. Maybe one day, we’ll make things better again. See you around! If you ever find something cool, let me know, okay?

 *   [(Leave)]
    -> END

-> END
