-> emma_intro

=== emma_intro ===

EMMA:
You must be the new one. I’m Emma. I oversee the lookouts here—make sure we gather what we can and keep an eye on any threats. We don’t have the luxury of missing anything, so I run a tight ship. My job’s to organize resource runs and make sure we don’t starve. It’s not easy, but it’s necessary. Out there, every piece of food, every drop of water counts. And I make sure we get it.

+   [“Sounds like a tough job. What is with this village?”]
    -> air_pollution

+   [“What happened here?”]
    -> air_pollution

+   [“What’s it like out there?”]
    -> air_pollution

=== air_pollution ===

EMMA:
Used to be, this place was full of life. People packed into buildings, cars clogging the streets, the air so bad you could hardly breathe. And then... the collapse. When the climate really went to hell, the air became poison. Factories, cars, everything kept running until it was too late. People tried to adapt, but it didn’t matter. The pollution choked the city—literally and figuratively. That’s why we don’t waste anything now. Every breath, every bite could be your last if you’re not careful. So here’s the deal. We’ve got water—clean water—but we’re short on food. If you can bring back enough, I’ll make sure you’re set with water. You won’t find a better offer around here.

+   [“What exactly are you looking for?”]
    -> quest_details

+   [“Sounds fair. I’ll take the job.”]
    -> accept_quest

+   [“I’m not sure if I’m up for this.”]
    -> decline_quest

=== quest_details ===

EMMA:
I need 2 slice of bread. Bring it to me, and I’ll trade you for water. Simple as that.

*   [“Alright, I’ll see what I can find.”]
    -> accept_quest

*   [“That sounds risky, but I’ll give it a shot.”]
    -> accept_quest

*   [“I don’t know if I’m ready for this.”]
    -> decline_quest

=== accept_quest ===

EMMA:
Good. You get me those supplies, and you’ll have enough water to last you a while. Just remember—time’s ticking, and there’s always someone else willing to take the deal if you back out. Start out there.

+ [(Leave)]
    -> END

=== decline_quest ===

EMMA:
Your choice. Just remember, out here, you don’t get many second chances. If you change your mind, I might still have work for you. Might.

+ [(Leave)]
    -> END
