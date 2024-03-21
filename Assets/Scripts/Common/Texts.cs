using System.Collections.Generic;

public static class Texts
{
    public static readonly TranslatedString[] StartDialog = new []
    {
        new TranslatedString
        {
            ru = @"Вот и ты, мой слуга. У меня есть задание для тебя.",
            en = @"There you are, my servant. I've got a task for you.",
        },
        new TranslatedString
        {
            ru = @"Мне осталось всего 280 частиц Зла для создания самого могущественного оружия во вселенной.",
            en = @"I have only 280 evil pieces left to create the most powerful weapon in the universe.",
        },
        new TranslatedString
        {
            ru = @"Ты должен отправиться в мир людей и посеять немного хаоса.",
            en = @"You have to go to the human world and sow a little chaos.",
        },
        new TranslatedString
        {
            ru = @"С собой ты возьмешь Сферу Зла. Она впитает все сотворенные тобой ужасы.",
            en = @"You will take the Sphere of Evil with you. It will absorb all the horrors you will made.",
        },
        new TranslatedString
        {
            ru = @"Как только будет накоплено достаточно, я перемещу тебя обратно.",
            en = @"As soon as enough is accumulated, I will transport you back.",
        },
        new TranslatedString
        {
            ru = @"...",
            en = @"...",
        },
        new TranslatedString
        {
            // ToDo: изменить
            ru = @"Знаешь... А ведь если подумать, ты станешь предвестником новой эры... Моей эры.",
            en = @"You know... If you think about it, you will become a harbinger of a new era... My era.",
        },
        new TranslatedString
        {
            ru = @"Но не волнуйся, ведь это также будет и началом ",
            en = @"But don't worry. It will be also the beginning of a new era... My era.",
        },
        new TranslatedString
        {
            ru = @"Что же, за работу.",
            en = @"Well, let's get to work.",
        },
    };

    public static readonly TranslatedString[] ExitDialog = new []
    {
        new TranslatedString
        {
            ru = @"Похоже, что ты собрал достаточно частиц зла.",
            en = @"It looks like you've gathered enough evil pieces.",
        },
        new TranslatedString
        {
            ru = @"Приготовься к перемещению.",
            en = @"Prepare to transportation.",
        },
        
    };

    public static readonly TranslatedString Controls = new TranslatedString
    {
        ru = @"Используй WASD для перемещения",
        en = @"Use WASD to move",
    };

    public static readonly TranslatedString[] BringMeTheWeapon = new[]
    {
        new TranslatedString
        {
            ru = @"Отлично, отлично. А теперь поднеси Сферу к пьедесталу, и принеси мне моё орудие уничтожения.",
            en = @"Good, good. Now bring the Sphere to the pedestal, and bring me my weapon of destruction.",
        },
    };

    public static readonly TranslatedString[] WhatInGoddamn = new[]
    {
        new TranslatedString
        {
            ru = @"ЧТО???!!",
            en = @"WHAT THE???!!",
        },
        new TranslatedString
        {
            ru = @"ДУДКА???!! И это оружие чистого зла?!",
            en = @"TRUMPET???!! That's the weapon of pure evil?!",
        },
    };

    public static readonly TranslatedString[] Ouch = new[]
    {
        new TranslatedString
        {
            ru = @"Что ты делаешь?",
            en = @"What are you doing?",
        },
        new TranslatedString
        {
            ru = @"Стой",
            en = @"Wait",
        },
        new TranslatedString
        {
            ru = @"ПРЕКРАТИ",
            en = @"STOP IT",
        },
        new TranslatedString
        {
            ru = @"ЕСЛИ ТЫ НЕ ПЕРЕ...",
            en = @"IF YOU DON'T ST...",
        },
    };

    public static readonly TranslatedString[] Titles = new[]
    {
        new TranslatedString
        {
            ru = @"Игру сделал kartofander специально для theBatya Game Jam 2021.2",
            en = @"Game was made by kartofander within theBatya Game Jam 2021.2",
        },
        new TranslatedString
        {
            ru = @"Использованный шрифт: Comic Sans MS Pixel. Copyright: JustAngelSQ 2017 “Sans” by “Ryan Brotherston”",
            en = @"Font used: Comic Sans MS Pixel. Copyright: JustAngelSQ 2017 “Sans” by “Ryan Brotherston”",
        },
        new TranslatedString
        {
            ru = @"Спасибо за игру!",
            en = @"Thanks for playing!",
        },
        new TranslatedString
        {
            ru = @"",
            en = @"",
        },
    };

    public static readonly Dictionary<string, TranslatedString> uiTranslations =
        new Dictionary<string, TranslatedString>()
        {
            ["interactionHint"] = new TranslatedString
            {
                ru = "Нажмите \"E\"",
                en = "Press \"E\"",
            },
            ["musicVolume"] = new TranslatedString
            {
                ru = "Музыка",
                en = "Music",
            },
            ["effectsVolume"] = new TranslatedString
            {
                ru = "Звуки",
                en = "Effects",
            },
            ["languageLabel"] = new TranslatedString
            {
                ru = "Язык",
                en = "Language",
            },
            ["language"] = new TranslatedString
            {
                ru = "Русский",
                en = "English",
            },
            ["exit"] = new TranslatedString
            {
                ru = "Выйти",
                en = "Exit",
            },
            ["hintLabel"] = new TranslatedString
            {
                ru = "Подсказка",
                en = "Hint",
            },
        };
}

public class TranslatedString
{
    public string ru;
    public string en;

    public string GetText()
    {
        return TranslationManager.instance.currentLanguage switch
        {
            Language.En => en,
            Language.Ru => ru,
            _ => en,
        };
    }
}
