-> village_entry

=== village_entry ===

MARCUS:
Here we are. Hard to believe this was once a thriving village, huh? Used to be families lived here, kids playing in the streets. Now, just empty shells of homes. The collapse hit this place hard, like everywhere else. But this isn't just a ghost town—there's something here we need. Stay sharp. These old places might seem empty, but they have a way of hiding things. We’re here for one reason—the computer. It’s buried somewhere in the heart of this place, and it’s our job to get it running again.

+   [“How do we get it running?”]
    -> mission_briefing

+   [“What’s the plan once we find the computer?”]
    -> mission_briefing

+   [“Why is this computer so important?”]
    -> mission_briefing

=== mission_briefing ===

MARCUS:
Somewhere in this village, there’s a computer that’s tied to the old power grid that we need to turnback on. It’s a piece of the puzzle, one of many we’ll need to get the main power station back online. But here’s the catch—each of these computers needs a specific hardware piece to function, and we only get one shot at it. When we find that computer, you’ll need to install the hardware piece. Make sure you choose the right one, because once it’s in, there’s no going back. The computer won’t start until it has what it needs.

+   [“How will I know which piece is the right one?”]
    -> piece_selection

+   [“What happens if I choose the wrong piece?”]
    -> wrong_piece_consequence

+   [“Got it. Let’s find that computer.”]
    -> explore_village

=== piece_selection ===

MARCUS:
Trust your instincts, but also look for clues. The tech from back then was built with some logic behind it. Look around—there might be something that points you in the right direction. Signs, markings, anything that seems off. The right piece should feel like it belongs.

*   [“I’ll be careful. Let’s keep moving.”]
    -> explore_village

*   [“Thanks, Marcus. I’ll keep that in mind.”]
    -> explore_village

=== wrong_piece_consequence ===

MARCUS:
If you put in the wrong piece, the computer will still work but consume more of our precious energy. So don’t rush it—think it through."

*   [“Alright, I’ll make sure to pick the right one.”]
    -> village


=== village ===

MARCUS:
Good. Let’s move. Start by searching the houses and any old shops. People used to hide all sorts of things in places like this, hoping to protect what they could when everything went to hell. The computer’s here somewhere, and so is the piece we need. Let’s find them. Remember, once we’ve got the computer working, we’ll be one step closer to getting that power back. But for now, focus on the task at hand. We’ll get through this. 

*   [“Understood. Let’s do this.”]
    -> explore_village
    
=== explore_village ===
MARCUS:
After you done, leave the Village and walk to the forest. I will meet you there.

+ [(Leave)]
    -> END
