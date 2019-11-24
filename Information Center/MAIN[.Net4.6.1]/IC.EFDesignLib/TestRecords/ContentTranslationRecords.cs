using IC.EFDesignLib.Interfaces;

namespace IC.EFDesignLib.TestRecords
{
    /// <summary>
    /// Presents Content Translation Test Records
    /// 
    /// 2017/04/18 - created VTyagunov
    /// </summary>
    class ContentTranslationRecords : IRecords
    {
        /// <summary>
        /// Use for Add Records to database
        /// </summary>
        public void AddRecordsToDB()
        {
            using (var context = new ICDBContext())
            {
                #region Language/Currency ID[1...7]

                #region ID = 1
                var translation = new ContentTranslation()
                {
                    TranslationID = 1,
                    LanguageCode = "RUS",                    
                    TranslationValue = "Русский"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 1,
                    LanguageCode = "ENG",
                    TranslationValue = "Russian"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 1,
                    LanguageCode = "CN",
                    TranslationValue = "俄"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 2
                translation = new ContentTranslation()
                {
                    TranslationID = 2,
                    LanguageCode = "RUS",
                    TranslationValue = "Английский"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 2,
                    LanguageCode = "ENG",
                    TranslationValue = "English"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 2,
                    LanguageCode = "CN",
                    TranslationValue = "英语"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 3
                translation = new ContentTranslation()
                {
                    TranslationID = 3,
                    LanguageCode = "RUS",
                    TranslationValue = "Китайский"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 3,
                    LanguageCode = "ENG",
                    TranslationValue = "China"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 3,
                    LanguageCode = "CN",
                    TranslationValue = "中国"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 4
                translation = new ContentTranslation()
                {
                    TranslationID = 4,
                    LanguageCode = "RUS",
                    TranslationValue = "Рубль"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 4,
                    LanguageCode = "ENG",
                    TranslationValue = "Ruble"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 4,
                    LanguageCode = "CN",
                    TranslationValue = "卢布"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 5
                translation = new ContentTranslation()
                {
                    TranslationID = 5,
                    LanguageCode = "RUS",
                    TranslationValue = "Доллар США"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 5,
                    LanguageCode = "ENG",
                    TranslationValue = "USD"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 5,
                    LanguageCode = "CN",
                    TranslationValue = "美元"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 6
                translation = new ContentTranslation()
                {
                    TranslationID = 6,
                    LanguageCode = "RUS",
                    TranslationValue = "Евро"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 6,
                    LanguageCode = "ENG",
                    TranslationValue = "Euro"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 6,
                    LanguageCode = "CN",
                    TranslationValue = "欧元"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 7
                translation = new ContentTranslation()
                {
                    TranslationID = 7,
                    LanguageCode = "RUS",
                    TranslationValue = "Юань"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 7,
                    LanguageCode = "ENG",
                    TranslationValue = "Yuan"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 7,
                    LanguageCode = "CN",
                    TranslationValue = "元"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #endregion

                #region ProductCaptionID[1001...1999]

                #region ID = 1001
                translation = new ContentTranslation()
                {
                    TranslationID = 1001,
                    LanguageCode = "RUS",
                    TranslationValue = "Амуаж. Женщина Чести"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 1001,
                    LanguageCode = "ENG",
                    TranslationValue = "Amouage Honour women"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 1001,
                    LanguageCode = "CN",
                    TranslationValue = "Amouage榮譽婦女"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 1002
                translation = new ContentTranslation()
                {
                    TranslationID = 1002,
                    LanguageCode = "RUS",
                    TranslationValue = "Hugo Boss Woman"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 1002,
                    LanguageCode = "ENG",
                    TranslationValue = "Hugo Boss Woman"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 1002,
                    LanguageCode = "CN",
                    TranslationValue = "Hugo Boss Woman"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 1003
                translation = new ContentTranslation()
                {
                    TranslationID = 1003,
                    LanguageCode = "RUS",
                    TranslationValue = "\"Man in Red\" от Ferrari Cavallino"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 1003,
                    LanguageCode = "ENG",
                    TranslationValue = "\"Man in Red\" Ferrari Cavallino"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 1003,
                    LanguageCode = "CN",
                    TranslationValue = "“紅人” Ferrari Cavallino"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 1004
                translation = new ContentTranslation()
                {
                    TranslationID = 1004,
                    LanguageCode = "RUS",
                    TranslationValue = "MSI Aegis-075RU, Чёрный"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 1004,
                    LanguageCode = "ENG",
                    TranslationValue = "MSI Aegis-075RU, Black"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 1004,
                    LanguageCode = "CN",
                    TranslationValue = "MSI Aegis-075RU, 黑色"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 1005
                translation = new ContentTranslation()
                {
                    TranslationID = 1005,
                    LanguageCode = "RUS",
                    TranslationValue = "Redmond RK-G127"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 1005,
                    LanguageCode = "ENG",
                    TranslationValue = "Redmond RK-G127"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 1005,
                    LanguageCode = "CN",
                    TranslationValue = "Redmond RK-G127"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 1006
                translation = new ContentTranslation()
                {
                    TranslationID = 1006,
                    LanguageCode = "RUS",
                    TranslationValue = "SAMSUNG UE50KU6000UXRU"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 1006,
                    LanguageCode = "ENG",
                    TranslationValue = "SAMSUNG UE50KU6000UXRU"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 1006,
                    LanguageCode = "CN",
                    TranslationValue = "SAMSUNG UE50KU6000UXRU"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #endregion

                #region ProductDescriptionID[2001...2999]

                #region ID = 2001
                translation = new ContentTranslation()
                {
                    TranslationID = 2001,
                    LanguageCode = "RUS",
                    TranslationValue = "Amouage Honour women («Амуаж. Женщина Чести») - это аромат для женщин. Создан в 2011 году. Авторы аромата – парфюмеры Александра Карлина и Violaine Collas. Парфюм принадлежит к группе ароматов восточные, цветочные. Симфония аромата станет идеальной гармонией во время рабочего дня и романтического вечера. Женский парфюм Amouage Honour Women обладает пряным цветочным ароматом, с роскошным и чувственным восточным шлейфом."
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 2001,
                    LanguageCode = "ENG",
                    TranslationValue = "Amouage Honor women (\"Amuage, Woman of Honor\") is a fragrance for women. It was created in 2011. The authors of the fragrance are perfumers of Alexander Karlin and Violaine Collas. Perfume belongs to the group of aromas oriental, floral. The symphony of fragrance will be an ideal harmony during a working day and a romantic evening. Women's perfume Amouage Honor Women has a spicy floral scent, with a luxurious and sensual oriental train."
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 2001,
                    LanguageCode = "CN",
                    TranslationValue = "Amouage榮譽的女性（«榮譽Amuazh女人“。） - 女性香味。成立於2011年。作者味道 - 香水亞歷山德拉卡林和維奧萊納Collas。香水屬於一組的東方味道，花香。香水交響樂團將在白天和一個浪漫的夜晚完美的和諧。女性香水Amouage榮譽婦女有辛辣花香調香水，擁有豪華的和感性的東方列車。"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 2002
                translation = new ContentTranslation()
                {
                    TranslationID = 2002,
                    LanguageCode = "RUS",
                    TranslationValue = "Hugo Boss Woman — настоящий подарок для элегантных, уверенных в себе современных женщин. Аромат Boss наполнен силой и энергией окружающего мира, его яркость и насыщенность соседствует с легкостью и утонченностью. Парфюм принадлежит к группе ароматов: цветочные фруктовые. Верхние ноты: мандарин и манго; ноты сердца: корень фиалки и белая фрезия; ноты базы: экстракт белого кедра и сандал."
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 2002,
                    LanguageCode = "ENG",
                    TranslationValue = "Hugo Boss Woman - a real gift for elegant, self-confident modern women. The fragrance of Boss is filled with the power and energy of the surrounding world, its brightness and richness adjoins with ease and refinement. Perfume belongs to the group of aromas: floral fruit. Top notes: Mandarin and mango; Heart notes: violet root and white freesia; Base notes: white cedar and sandalwood extract."
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 2002,
                    LanguageCode = "CN",
                    TranslationValue = "Hugo Boss的女人 - 為優雅，自信，現代女性一個真正的禮物。老闆芳香滿人間的力量和能量，亮度和飽和度是鄰近的易用性和複雜性。香水屬於一組味道：花香果。柑橘和芒果的前調;中調為紫色根和白小蒼蘭;基調為白色雪松和檀香提取物。"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 2003
                translation = new ContentTranslation()
                {
                    TranslationID = 2003,
                    LanguageCode = "RUS",
                    TranslationValue = "Мужская туалетная вода \"Man in Red\" от Ferrari Cavallino - это аромат, принадлежащий к группе ароматов фужерные. Верхние ноты - бергамот, кардамон и красное яблоко; ноты сердца - желтая слива, апельсиновый цвет и лаванда; ноты базы - лабданум, белый кедр и тонка бобы. Объем 50 мл."
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 2003,
                    LanguageCode = "ENG",
                    TranslationValue = "Men's toilet water \"Man in Red\" from Ferrari Cavallino is an aroma belonging to the group of aromas of fougères. The top notes are bergamot, cardamom and red apple; Heart notes - yellow plum, orange blossom and lavender; Base notes are labdanum, white cedar and thin beans. Volume of 50 ml."
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 2003,
                    LanguageCode = "CN",
                    TranslationValue = "男士淡香水“人紅” Ferrari Cavallino - 屬於一組蕨類植物香味的香味。前調 - 佛手柑，小荳蔻和紅蘋果;中調 - 梅子黃，橙花和薰衣草;基調 - 勞丹脂，白雪松和黑香豆。為50毫升的體積。"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 2004
                translation = new ContentTranslation()
                {
                    TranslationID = 2004,
                    LanguageCode = "RUS",
                    TranslationValue = "MSI Aegis – это настоящая боевая бронемашина, разработанная с нуля для единственной цели – стать совершенной платформой защиты и нападения. Для создания Aegis были отобраны только самые лучшие компоненты. Производительность этого десктопа подобна скорости самурайского меча, а внешний облик отточен до мельчайшего изгиба. Верное оружие для настоящих чемпионов."
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 2004,
                    LanguageCode = "ENG",
                    TranslationValue = "MSI Aegis is a real combat armored car, designed from the ground up for the sole purpose - to become the perfect platform for protection and attack. To create Aegis, only the best components were selected. The performance of this desktop is similar to the speed of the samurai sword, and the exterior is refined to the smallest bend. A true weapon for real champions."
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 2004,
                    LanguageCode = "CN",
                    TranslationValue = "MSI Aegis - 一個真正的戰鬥裝甲車，從地上爬起來的唯一目的設計 - 成為防禦和攻擊一個完美的平台。只有最好的組件選擇創建神盾。這款台式機的性能類似於日本武士刀的速度和外觀完善，以最小的彎曲。對於真正的冠軍合適的武器。"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 2005
                translation = new ContentTranslation()
                {
                    TranslationID = 2005,
                    LanguageCode = "RUS",
                    TranslationValue = "Мощность 1850-2200 Вт Напряжение 220-240 В, 50-60 Гц Объем 1,7 л Материал корпуса жаропрочное стекло, нержавеющая сталь Фильтр от накипи Автоотключение при закипании Автоотключение при отсутствии воды Дисковый нагревательный элемент Внутренняя подсветка колбы Вращение на подставке 360? Длина шнура 0,7 м Отсек для хранения шнура"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 2005,
                    LanguageCode = "ENG",
                    TranslationValue = "Power 1850-2200 W Voltage 220-240 V, 50-60 Hz Volume 1,7 l Body material heat-resistant glass, stainless steel Scale filter Auto-shut-off at boiling Automatic shutdown in the absence of water Disc heating element Internal bulb lighting Rotation on the stand 360? Cord length 0,7 m Cord storage"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 2005,
                    LanguageCode = "CN",
                    TranslationValue = "功率一八五○年至2200年W電壓220-240伏，50-60赫茲位移1.7升耐熱材料套色玻璃，以在載體上360不存在水加熱元件內部盤燈泡燈旋轉刻度自動自動沸騰的不銹鋼過濾器？電線長度0.7米帘線寄存"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 2006
                translation = new ContentTranslation()
                {
                    TranslationID = 2006,
                    LanguageCode = "RUS",
                    TranslationValue = "Благодаря функции HDR Premium вы можете при просмотре HDR контента разглядеть детали в светлых участках изображения, невидимые ранее. Наконец-то вы сможете получить впечатления от просмотра HDR контента дома в своей комнате как в настоящем кинотеатре."
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 2006,
                    LanguageCode = "ENG",
                    TranslationValue = "Thanks to the function HDR Premium, you can see the details in the light areas of the image, previously unseen, when viewing HDR content. Finally, you can get an impression of viewing HDR content at home in your room like a real cinema."
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 2006,
                    LanguageCode = "CN",
                    TranslationValue = "隨著功能HDR付費就可以觀看時的根據HDR看到的內容在圖像的明亮區域，以前看不到的細節。最後，你可以得到內容HDR回家的他在一個真正的影院房間的觀看體驗。"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #endregion

                #region StoreCaptionID[10001...10999]

                #region ID = 10001
                translation = new ContentTranslation()
                {
                    TranslationID = 10001,
                    LanguageCode = "RUS",
                    TranslationValue = "Магазин S001"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 10001,
                    LanguageCode = "ENG",
                    TranslationValue = "Store S001"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 10001,
                    LanguageCode = "CN",
                    TranslationValue = "商店 S001"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 10002
                translation = new ContentTranslation()
                {
                    TranslationID = 10002,
                    LanguageCode = "RUS",
                    TranslationValue = "Магазин S002"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 10002,
                    LanguageCode = "ENG",
                    TranslationValue = "Store S002"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 10002,
                    LanguageCode = "CN",
                    TranslationValue = "商店 S002"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #endregion

                #region  RetailActionProductCaptionID[100001...100999]

                #region ID = 100001
                translation = new ContentTranslation()
                {
                    TranslationID = 100001,
                    LanguageCode = "RUS",
                    TranslationValue = "Неделя больших скидок!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 100001,
                    LanguageCode = "ENG",
                    TranslationValue = "Week of great discounts!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 100001,
                    LanguageCode = "CN",
                    TranslationValue = "巨大折扣的一周！"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 100002
                translation = new ContentTranslation()
                {
                    TranslationID = 100002,
                    LanguageCode = "RUS",
                    TranslationValue = "Hugo Boss +3 бесплатно!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 100002,
                    LanguageCode = "ENG",
                    TranslationValue = "Hugo Boss +3 for free!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 100002,
                    LanguageCode = "CN",
                    TranslationValue = "Hugo Boss +3 免費！"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 100003
                translation = new ContentTranslation()
                {
                    TranslationID = 100003,
                    LanguageCode = "RUS",
                    TranslationValue = "Стань победителем!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 100003,
                    LanguageCode = "ENG",
                    TranslationValue = "Become a winner!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 100003,
                    LanguageCode = "CN",
                    TranslationValue = "成為贏家！"
                };
                context.ContentTranslation.Add(translation);
                #endregion
                
                #endregion

                #region RetailActionProductDescriptionID[101001...101999]

                #region ID = 101001
                translation = new ContentTranslation()
                {
                    TranslationID = 101001,
                    LanguageCode = "RUS",
                    TranslationValue = "Только у нас, до конца недели действует акция \"Неделя больших скидок!\", по которой Вы можете преобрести любую парфюмерию со скидкой 35%! Успейте купить отличной подарок своим любимым, и не забудьте порадовать себя!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 101001,
                    LanguageCode = "ENG",
                    TranslationValue = "Only with us, till the end of the week there is an action \"Week of big discounts!\", On which you can buy any perfume with a discount of 35%! Have time to buy a great gift for your loved ones, and do not forget to glad yourself!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 101001,
                    LanguageCode = "CN",
                    TranslationValue = "只有我們，“大折扣的週！”動作有效期至本週結束的，你可以在35％的折扣購買任何香水！有時間買一個偉大的禮物給你的親人，不要忘記善待自己！"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 101002
                translation = new ContentTranslation()
                {
                    TranslationID = 101002,
                    LanguageCode = "RUS",
                    TranslationValue = "При покупке духов марки Hugo Boss вы получите 3! пробника духов данной марки на Ваш выбор!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 101002,
                    LanguageCode = "ENG",
                    TranslationValue = "When buying perfume brand Hugo Boss you will get 3! A sampler of perfume of this brand for your choice!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 101002,
                    LanguageCode = "CN",
                    TranslationValue = "當購買的Hugo Boss品牌的香水，你拿到3！品牌您所選擇的香水測試！"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 101003
                translation = new ContentTranslation()
                {
                    TranslationID = 101003,
                    LanguageCode = "RUS",
                    TranslationValue = "При покупке компьютера MSI Aegis-075RU Вы получите купон на участие в розыгрыше призов, который будет проводиться в конце недели, возможно именно Вас ждём главный приз!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 101003,
                    LanguageCode = "ENG",
                    TranslationValue = "When you purchase a MSI Aegis-075RU computer, you will receive a coupon for participation in the prize draw, which will be held at the end of the week, maybe you are waiting for the main prize!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 101003,
                    LanguageCode = "CN",
                    TranslationValue = "當購買一台計算機 MSI Aegis-075RU 您將收到一張優惠券，參與抽獎，將在週末舉行，也許你正在等待巨獎！"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #endregion

                #region  RetailActionStoreCaptionID[110001...110999]

                #region ID = 110001
                translation = new ContentTranslation()
                {
                    TranslationID = 110001,
                    LanguageCode = "RUS",
                    TranslationValue = "Розыгрышь призов от нашего магазин!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 110001,
                    LanguageCode = "ENG",
                    TranslationValue = "Prize drawing from our store!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 110001,
                    LanguageCode = "CN",
                    TranslationValue = "從我們的商店抽獎活動！"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 110002
                translation = new ContentTranslation()
                {
                    TranslationID = 110002,
                    LanguageCode = "RUS",
                    TranslationValue = "Оформление скидочных карт!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 110002,
                    LanguageCode = "ENG",
                    TranslationValue = "Registration of discount cards!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 110002,
                    LanguageCode = "CN",
                    TranslationValue = "清倉打折卡！"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 110003
                translation = new ContentTranslation()
                {
                    TranslationID = 110003,
                    LanguageCode = "RUS",
                    TranslationValue = "Акции и конкурсы!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 110003,
                    LanguageCode = "ENG",
                    TranslationValue = "Actions and contests!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 110003,
                    LanguageCode = "CN",
                    TranslationValue = "促銷和比賽！"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #endregion

                #region RetailActionStoreDescriptionID[111001...111999]

                #region ID = 111001
                translation = new ContentTranslation()
                {
                    TranslationID = 111001,
                    LanguageCode = "RUS",
                    TranslationValue = "Примите участие в розыгрыше призов от нашего магазина, главный приз автомобиль! Море подарков и призов ждус Вас!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 111001,
                    LanguageCode = "ENG",
                    TranslationValue = "Take part in drawing prizes from our store, the main prize is a car! A lot of gifts and prizes are waiting for you!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 111001,
                    LanguageCode = "CN",
                    TranslationValue = "參加從我們的商店，汽車的主要獎項獎品的抽獎活動！海禮品和獎品zhdus你！"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 111002
                translation = new ContentTranslation()
                {
                    TranslationID = 111002,
                    LanguageCode = "RUS",
                    TranslationValue = "При покупке товаров, проходящих по акциям, мы бесплатно предоставим Вам скидочную карту нашего магазина, которая будет накапливать и суммировать баллы за Ваши покупки, экономьте на своих покупках!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 111002,
                    LanguageCode = "ENG",
                    TranslationValue = "When buying goods, passing through the shares, we will give you a discount card of our store for free, which will accumulate and summarize the points for your purchases, save on your purchases!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 111002,
                    LanguageCode = "CN",
                    TranslationValue = "當購買商品經過股，是免費的，我們為您提供我們的商店的打折卡，這將收集並總結點為您的購買，節省他們的購買！"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #region ID = 111003
                translation = new ContentTranslation()
                {
                    TranslationID = 111003,
                    LanguageCode = "RUS",
                    TranslationValue = "В конце каждой недели в нашем магазине проводятся акции и конкурсы, примите в них участие, и получите интересные подарки от наших организоторов, проводите время интересно и весело вместе с нами!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 111003,
                    LanguageCode = "ENG",
                    TranslationValue = "At the end of each week, our store holds promotions and competitions, take part in them, and receive interesting gifts from our organizers, spend time interesting and fun together with us!"
                };
                context.ContentTranslation.Add(translation);

                translation = new ContentTranslation()
                {
                    TranslationID = 111003,
                    LanguageCode = "CN",
                    TranslationValue = "每個週末在我們的商店結束時進行的動作和比賽，參與其中，並獲得有趣的禮物，從我們的組織者花時間有趣和樂趣與我們！"
                };
                context.ContentTranslation.Add(translation);
                #endregion

                #endregion

                context.SaveChanges();
            }
        }
    }
}