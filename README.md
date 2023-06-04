# **K-AJD - Izbor in tisk proizvodnih načrtov glede na naročilo stranke**

### **_Opis_**

Projekt je rešitev problema iskanja in tiskanja načrtov iz naročila, ki ga stranka prejme.

Rešitev je sestavljena iz dveh delov:
- namizne aplikacije
- Outlook addin-a

### **_Delovanje rešitve_**
Uporabnik zažene Outlook aplikacijo s dodanim Add-inom in namizno aplikacijo preko .exe datoteke.
Outlook addin:
- Stranka prejme naročilnico na Outlook, kjer z desnim klikom na njo omogoči pošiljanje naročilnice v namizno aplikacijo.

Namizna aplikacija:
- naročilnico prejme preko Outlook addina ali jo naložimo ročno
- v naročilnici najde serijske številke, ki pripadajo shranjenim načrtom
- načrte "watermarka" in natisne

### **_Tehnologije_**

Rešitev uporablja različne tehnologije:
| Tehnologija | Info |
| ------ | ------ |
| Winforms | [Winforms .NET Core 7.0.5][PlDb] |
| VSTO(Visual Studio Tools for Office) Outlook Add-in | [Outlook Add-in .NET Framework 4.8][PlGh] |

| Programski jezik | Info |
| ------ | ------ |
| C# | [A tour of C#][PlCh] |

### **_Namestitev_**
Glede na to, da stranka potrebuje rešitev lokalno na enem računalniku, smo se odločili, da ne ustvarjamo installerja, ampak 
jim rešitev namestimo sami.

Za namestitev projekta so potrebni:
- .NET Core 7.0.5
- .NET Framework 4.8
- VSTO Runtime
- Outlook 2016+(Microsoft 365 ali Office verzija)
- Windows 10+

### **_Razvoj_**
Za razvoj smo izbrali okolje Visual Studio 2022. Uporabili smo 2 knjižnici za delo z pdf-ji in sicer [iTextSharp][PlIt] in [Apitron][PlAp]. Projekt smo začeli razvijati preko VSTO template-a in nato gradili po priporočilih dokumentacije.
##### Namizna aplikacija
Za izgled namizne aplikacije smo uporabljali Visual Studio designer-ja, ki ponuja ročno sestavljanje namiznih aplikacij. Preko njega smo dodajali vnaprej definirane evente, ki so vezani na komponente izgleda aplikacije.

##### Outlook add-in
Outlook add-inu smo gumb dodali preko Ribbona(XML), ki je način spreminjanje izgleda Office aplikacij in se doda k originalnim komponentam office aplikacije. Do dokumenta dostopa preko office object-a Attachment.





[//]: # 
   [PlDb]: <https://github.com/dotnet/winforms>
   [PlGh]: <https://learn.microsoft.com/en-us/visualstudio/vsto/outlook-solutions?view=vs-2022>
   [PlCh]: <https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/>
   [PlIt]: <https://itextpdf.com/products/itextsharp/>
   [PlAp]: <https://www.apitron.com/>
   
   
   
