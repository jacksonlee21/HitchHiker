﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Storys
{
    public static string[] wakeUpDialogue = new string[] {
        "Buff Guy: Hey, get up. Where’s my wallet?",
        "You: What?",
        "Buff Guy: Don’t play dumb with me, my buddies saw you do it before you slinked away.",
        "Buff Guy: If you don’t give it back I’m pressing charges.",
        "You: I don’t have your wallet!",
        "Buff Guy: Not my problem. Get it back or else."
    };
    public static string[] preChefDialogue = new string[] {
        "Chef: HEY! Don’t think you can walk away after what you did! Get in here and fix this before I call the cops!" ,
        "You: Are you talking to me?" ,
        "Chef: Yes I’m talking to you! Don’t think for a second that I’ll let this slide, you owe me big time!" ,
        "You: I’m sorry but I don’t know you." ,
        "Chef: That’s convenient. Get in the kitchen, NOW!" 
    };

    public static string[] postChefDialogue = new string[] {
        "Chef: Ok, you’ve paid your debt, you’re free to go.",
        "You: I'm sorry for whatever I did last night.",
        "Chef: 'Sorry' won't fix the soup you bathed in.",
        "You: ...I’ll see you later." ,
        "Chef: I hope not."
    };

    public static string[] preBikePumpDialogue = new string[] {
        "You: Why are you crying?",
        "Kid: Some jerk buried my basketball in my yard, and when I dug it up it was completely deflated. Who would do something like that?",
        "You: What a maniac.",
        "Kid: They even took my pump. Now what am I gonna do?",
        "You: I got a bike pump.",
        "Kid: Really? Thanks mister. Not many people would do all this for someone they didn’t know.",
        "You: Well in a sense I kinda owe you.",
        "Kid: Why?",
        "You: Remember how we were talking earlier about the jerk who buried your ball?",
        "Kid: ....",
        "You: ....",
        "Kid: ...no",
        "You: That wasn't really me, I was just drunk.",
        "Kid: drunk?",
        "You: Well, sometimes adult drink a magic potion that...",
        "Kid: I know what drunk means you donut, and honestly, I don't see the point",
        "You: Well it makes you feel better.",
        "Kid: Really? Cause bullying a kid wouldn't make me feel better.",
        "You: Well it makes you feel better if you don't drink too much.",
        "Kid: Well I’ll never drink if it means I’ll end up like you.",
        "You: Well I’m not like that all the time.",
        "Kid: Just pump up the ball"
    };
    public static string[] postBikePumpDialogue = new string[] {
        "You: ...I’m sorry",
        "Kid: Whatever.",
        "You: (That’s what saying sorry gets you)"
    };

    public static string[] preLudoDialogue = new string[] {
        "Man: You?! What are you doing here?",
        "You: Do I know you?",
        "Man: 'Do I know you?' You threw up on my porch and the roaches came.",
        "Man: Now I have to waste money on an exterminator.",
        "You: I don't remember that.",
        "Man: Well I do. Get in there and fix it before I an exterminator for you too.",
    };

    public static string[] postLudoDialogue = new string[] {
        "You: All cleaned up.",
        "Man: Congratulations, you're almost a good person.",
        "You: Hey man, come on.",
        "Man: You come on. I woke up with cockroaches in my slippers. Move along.",
        "You: :(",
    };

    public static string[] preEdnaDialogue = new string[] {
        "Old Lady: Young man you were downright crazy last night. I barely got any sleep with the havoc you cause.", 
        "You: I’m sorry ma'am, I don't remember much.",
        "Old Lady: You asked if I could spare any money, and when I turned you away you kicked the compost bin over",
        "Old Lady: You went into a rage spreading the freshly picked weeds around the yard, and now they've taken root.",
        "Old Lady: My bones are too old to do all this labor. Get to work before I call your mama."
    };

    public static string[] postEdnaDialogue = new string[] {
        "Old Lady: Well good job there ya young punk. Just about made things up to me.",
        "Old Lady: However you still my daughter for what you did last night. She's the house to the left at the edge of town.",
        "Old Lady: She's to stubborn to ask for help, but tell her Edna sent you and she will.",
        "You: What did I do?",
        "Edna: Go there and find out.",
        "Edna: And while you're down there ask her about your disease. She fights the same battle.",
        "You: Disease?",
        "Edna: Just ask, now get out of here!"
    };

    public static string[] preNinaDialogue = new string[] {
        "You: Are you Edna's daughter?",
        "Nina: My name is Nina.",
        "Nina: As you can probably guess you came through here last night.",
        "You: I'm truely sorry for what I've done to your town. I never expected It could go so bad.",
        "Nina: The sun's getting low. You should clean up here before it gets dark.",
        "Nina: Come in for a chat after you're done.",
        "You: Sounds good"
    };
    public static string[] postNinaDialogue = new string[] {
        "Nina: I appreciate you making things up. Come on it's getting cold out.",
        /*"Nina: So, has the fallout from last night made you have any realizations?",
        "You: I just need to drink less, I mean I've never let myself get that bad before.",
        "Nina: So you have blacked out before?",
        "You: I mean a few times but It's not that weird.",
        "Nina: You know my mom?",
        "You: Ya, she seems like quite the character.",
        "Nina: Thank god she is. I had a similar problem to yours.",
        "Nina: I’m sure you remember the big economic crash",
        "You: Of course, everyone suffered.",
        "Nina: We all have our story’s from that time.",
        "Nina: Mine starts when I get my hours cut at work.",
        "Nina: Edna is a diabetic, probably all those sweets she bakes.",
        "You: Bless her heart she’s so sweet.",
        "Nina: She is. Well I was helping pay for the meds cause she couldn't afford them.",
        "Nina: Those god damn big pharma CEOs. How can they keep that on their conscience? Sorry, I digress.",
        "Nina: Well after not working as much I struggled as well. I had to dip into the savings I set aside to get my psychology degree.",
        "Nina: I've always wanted to help others",
        "Nina: I covered the first few payments but soon It became clear that even my savings wouldn't be able to keep Edna alive long enough.",
        "Nina: Even though all this was going on I still had to have some fun. Mental health was at an all time low.",
        "You: I’m so sorry to hear this. I thought that I had it bad.",
        "Nina: Oh that was bad but recoverable.",
        "Nina: What I really want you to pay attention to is this next part.",
        "You: Sorry, continue.",
        "Nina: Anyways, my gals and I decided to go to the casino.",
        "Nina: We were responsible and set a limit of 20 dollars each, no more.",
        "Nina: Well, I was awfully lucky that night. Turned that twenty into three hundred!",
        "Nina: However happy I was the owners were probably ten times happier, they had just created a very profitable customer.",
        "Nina: I was ecstatic. That was a month's worth of meds rights there.",
        "Nina: I decided to try again. This time giving myself a budget of a hundred dollars.",
        "Nina: This time I left with fifty dollars.",
        "Nina: Well you can probably imagine where that led me.",
        "Nina: Every weekend I went back hoping for more.",
        "Nina: It became more than a way to help my mom, it was a way for me to cope.",
        "Nina: Sitting there I felt safe from the problems around me. But as my savings blew away I began to ask to borrow friends' money.",
        "Nina: Little bits here and there. As they began to catch on I would tell them how Edna needed the money.",
        "Nina: They would reluctantly hand it over feeling sorry for her.",
        "Nina: Instead of just using it for her meds I went to the casino hoping to get the same payout that I did my first time.",
        "Nina: This is the thing with addiction, you keep doing this thing past the point of enjoyment.",
        "Nina: What starts as an occasional activity becomes the center of your life.",
        "Nina: You begin to put your addiction in front of those you love. I hurt those around me.",
        "Nina: When they found out about my addiction they were hurt. I lied to them and essentially stole their money.",
        "You: My condolences. I can't imagine how you felt." ,
        "Nina: I think you can imagine.",
        "You: In what way?",
        "Nina: Well look back on your day. What have you spent today doing?" ,
        "You: Cleaning up after my mess.",
        "Nina: You were doing more than that. You were reconciling all the people you wronged.",
        "Nina: I did the same thing after my family and friends found out about my problem.",
        "Nina: You've made things back up to people, but know what are you going to do in order to make sure this never happens again?" ,
        "You: I’ll just give myself a limit to how much I drink. When I start to feel myself go I stop.",
        "Nina: I made the same excuse for myself, as soon as I lost a round I was supposed to quit, but much like drinking when you're in the heat of the moment your judgment is impaired." ,
        "Nina: You can’t give yourself a limit, or a certain case scenario. You have to stop completely.",
        "Nina: I get that it can be hard to admit to yourself you have a problem, but you don't have to.",
        "Nina: The destruction you caused this town is evidence you have a problem.",
        "Nina: People drink all the time without causing that much of a problem. I had to overcome my addiction. It's time for you to overcome yours.",
        "You: Come on, not even a drink at a birthday party? I think it’s a bit ridiculous. I've only had this one time that things went wrong.",
        "Nina: Today you were forced to face the damage you caused, but have you ever thought that you may have been causing damage back home without ever coming to realise it?",
        "Nina: What do you think the people you love would say about your relationship with alcohol?",
        "You: I’m not entirely sure but admittedly probably not great.",
        "Nina: I’d try asking, and maybe find your local AA meetings. Listen to others with the same issue.",
        "You: I'll give it a try. Even though it's only been a day I really like this town. Full of resilient folk.",
        "Nina: Can always come and visit.",*/
        "You: Well I’ll get out of your hair now. I really appreciate all that you have done.",
    };

}
