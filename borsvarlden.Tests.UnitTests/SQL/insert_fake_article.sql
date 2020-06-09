insert into FinwireNews 
(title,     /* 1 */
Slug,       /* 2 */
NewsText,   /* 3 */
Date,       /* 4 */
IsBorsvarldenArticle, /* 5 */ 
IsAdvertising,        /* 6 */  
CompanyName,          /* 7 */
ImageRelativeUrl,     /* 8 */
IsPublished           /* 9 */
)values 

('EG7 redovisar omsättningstillväxt om nästan 1000 %',  /* 1 */
'fake-news-title',   /* 2 */
                     /* 3 */                      
'Under det första kvartalet 2020 har vår nettoomsättning vuxit med nästan 1000 % från 14,8 Mkr till 155,5 Mkr på koncernnivå i förhållande till samma kvartal 2019. Under början av året har vi också genomfört en nyemission och kunnat välkomna Dan Sten Olsson med familj som nya huvudägare i EG7. Vi har en spännande tid framför oss med över 20 spelprojekt i pipelinen för spelutvecklingsdelen och över 40 planerade marknadsföringskampanjer för Petrol. Minst 6 förlagda spel släpps under andra halvåret 2020.

Tillförts 119 Mkr
Intresset för EG7 har visat sig vara mycket stort. Vi har nyligen slutfört en riktad nyemission som tillför koncernen cirka 119 Mkr. Detta ger oss en stor trygghet och stabilitet samtidigt som det skapar goda förutsättningar för ytterligare stark tillväxt.

Vi välkomnar också Dan Sten Olsson med familj tillsammans med Erik Nielsen som nya storägare i koncernen. Nielsen tar också plats i styrelsen och bidrar enormt med sin gedigna erfarenhet inom både spel- och finansbranschen. I den senaste emissionen deltog även flertalet internationella samt inhemska institutionella aktörer.

Covid-19
Covid-19 har slagit hårt mot världsekonomin. Vi följer kontinuerligt läget och har vidtagit flera åtgärder för att följa de regler och riktlinjer som gäller i de länder där vi verkar. Det är i dessa tider som det blir än mer tydligt att vår diversifierade affärsmodell skapar stabilitet i intäkterna. Våra anställda är vana vid att arbeta på distans och vi har virtuella nätverk på plats för att kunna hantera en situation av denna typ.

Generellt ser efterfrågan för spel en uppåtgående trend och särskilt under dessa tider främjar det oss. Fysisk speldistribution kan bli negativt påverkad men framgången under året för vår förläggarverksamhet bygger främst på digital distribution vilket gynnas av rådande förhållanden.

Vår marknadsföringsenhet Petrol ser en förskjutning i de externa projekten från det andra till tredje kvartalet i samband med att lanseringen av flertalet speltitlar skjuts framåt vilket kommer att påverka koncernens resultat. Samtidigt använder vi Petrol för att fokusera på interna projekt och bygga en god varumärkesgrund för det växande antalet egenutvecklade titlar.',
GETDATE(),           /* 4 */
1,                   /* 5 */
1,                    /* 6 */     
'EG7',                /* 7 */
'assets/images/custom/backfill/Borsvarlden_Artikel_Bild1-960x540.jpg', /* 8 */
1                   /* 9 */
)                   
