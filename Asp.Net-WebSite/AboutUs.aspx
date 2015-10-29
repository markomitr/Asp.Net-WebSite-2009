<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" Title="Untitled Page" %>
<asp:Content ID="headC" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="sodrzinaC" ContentPlaceHolderID="sodrzina" runat="Server">
           <div id="scripta" runat="server">
        </div>
   <%-- <div id="Mk" runat="server">--%>
        <div class="naslovAboutClients">
            <asp:Localize runat="server" Text="<%$ Resources:Page,NaslovAboutUs %>"></asp:Localize>
        </div>
        <img src="Images/Zanas.jpg" />
        <div class="tekstAboutUs">
           <asp:Localize runat="server" Text="<%$ Resources:Sodrzina,AboutUsVoved %>"></asp:Localize>
        </div>
        <div id="meniBarAbout">
            <ul>
                <li id="InfoTeam"><a href="#"><asp:Localize runat="server" Text="<%$ Resources:Meni,AboutUsOurTeam %>"></asp:Localize></a></li>
                <li id="Partneri"><a href="#"><asp:Localize runat="server" Text="<%$ Resources:Meni,AboutUsPartners %>"></asp:Localize></a></li>
            </ul>
        </div>
        <div id="infoteam" class="tekst">
            <div class="naslovAboutClients">
                <asp:Localize runat="server" Text="<%$ Resources:Sodrzina,AboutUsAplikativenNaslov %>"></asp:Localize>
            </div>
            <div class="tekstAboutUs">
                <img src="Images/SupportHelp.jpg" />
                 <asp:Localize runat="server" Text="<%$ Resources:Sodrzina,AboutUsAplikativen %>"></asp:Localize>
            </div>
            <div class="naslovAboutClients">
                <asp:Localize runat="server" Text="<%$ Resources:Sodrzina,AboutUsTehnickaNaslov %>"></asp:Localize>
            </div>
            <div class="tekstAboutUs">
                <img src="Images/SupportTeh.jpg" />
                    <asp:Localize runat="server" Text="<%$ Resources:Sodrzina,AboutUsTehnicka %>"></asp:Localize>
            </div>
            <div class="naslovAboutClients">
                 <asp:Localize runat="server" Text="<%$ Resources:Sodrzina,AboutUsObukaNaslov %>"></asp:Localize>
            </div>
            <div class="tekstAboutUs">
                <img src="Images/SupportObuka.jpg" />
                <asp:Localize runat="server" Text="<%$ Resources:Sodrzina,AboutUsObuka%>"></asp:Localize>
            </div>
            <div class="naslovAboutClients">
                <asp:Localize runat="server" Text="<%$ Resources:Sodrzina,AboutUsTimNaslov %>"></asp:Localize>
            </div>
            <div class="tekstAboutUs">
                <img src="Images/SupportTeam.jpg" />
                <asp:Localize runat="server" Text="<%$ Resources:Sodrzina,AboutUsTim %>"></asp:Localize>
            </div>
        </div>
        <div id="partneri" class="tekst">
            <div class="naslovAboutClients">
                <asp:Localize runat="server" Text="<%$ Resources:Sodrzina,AboutUsBrendoviNaslov %>"></asp:Localize>
            </div>
            <div class="tekstAboutUs">
                <img src="Images/BestBrands.jpg" />
                <asp:Localize runat="server" Text="<%$ Resources:Sodrzina,AboutUsBrendovi %>"></asp:Localize>
            </div>
            <div class="naslovAboutClients">
                <asp:Localize runat="server" Text="<%$ Resources:Sodrzina,AboutUsSymbolNaslov %>"></asp:Localize>
            </div>
            <div class="tekstAboutUs">
                <img src="Images/SymbolLogo.jpg" />
                <asp:Localize runat="server" Text="<%$ Resources:Sodrzina,AboutUsSymbol %>"></asp:Localize>
                
            </div>
            <div class="partneriAboutSliki">
                <img src="Images/HPlogo.jpg" /><img src="Images/Msilogo.jpg" /><img src="Images/WDlogo.jpg" /><img
                    src="Images/Linksys.jpg" /><img src="Images/Microsoft.jpg" /><img src="Images/Samsunglogo.jpg" />
            </div>
        </div>
        
<%--    </div>
    
   <div id="EN" runat="server">
        <div class="naslovAboutClients">
            About Us
        </div>
        <img src="Images/Zanas.jpg" />
        <div class="tekstAboutUs">
            &nbsp&nbsp&nbsp <b>Info Biro</b> EN EN е независна компанија која се занимава со изработка
            на апликативен софтвер и продажба на компјутерска опрема со седиште во Охрид, Република
            Македонија.
            <p>
                <b>Нашата цел е решенијата да ги прилагодиме кон специфичните потреби на нашите клиенти.</b></p>
            &nbsp&nbsp&nbsp Нашиот тим е специјализиран за поставување и инсталација на апликативен
            софтвер и комјутерска опрема во мрежно опкружување. Развиваме ефективни решенија
            во следните области: Интернет/Интранет решенија, изработка на апликативен софтвер,
            користење на бази на податоци, продажба на компјутерска опрема. Без разлика дали
            Ви е потребен интегриран мрежен систем, комpјутерска опрема и галантерија или пак
            Ви е потребан надградба на постоечкио систем, <b>ИНФО Биро</b> е вистинскиот избор
            за Вашите потреби.
        </div>

        <div id="meniBarAbout">
            <ul>
                <li id="InfoTeam"><a href="#">Our Team</a></li>
                <li id="Partneri"><a href="#">Partners</a></li>
            </ul>
        </div>
        <div id="infoteam" class="tekst">
            <div class="naslovAboutClients">
                Поддршка на апликативниот софтвер
            </div>
            <div class="tekstAboutUs">
                <img src="Images/SupportHelp.jpg" />
                &nbsp&nbsp&nbsp Нашиот технички тим е добро упатен во повекето од сегашните големи
                бизнис апликации и ги имаат при рака сите средства потребни за да ги добиете резултатите
                што ви требаат. Нашите аналитичари имаат широка основа на искуство кое доаѓа од
                работењето со апликациите кои се водечки во денешните бизниси.
            </div>
            <div class="naslovAboutClients">
                Техничка поддршка
            </div>
            <div class="tekstAboutUs">
                <img src="Images/SupportTeh.jpg" />
                &nbsp&nbsp&nbsp Гарантираме за производите кои ќе ги набавите кај нас а воедно ќе
                ја имате нашата поддршка во Вашиот стремеж за интегрирање во новите технологии.
                Нашиот тим знае како да Ви ги пренесе потребните информации и знаење.
            </div>
            <div class="naslovAboutClients">
                Обука
            </div>
            <div class="tekstAboutUs">
                <img src="Images/SupportObuka.jpg" />
                &nbsp&nbsp&nbsp По инсталацијата на апликативниот софтвер и компјутерска опрема
                ИНФО Биро обезбедува сеопфатна обука така да клиентот ќе може да ја стекне потребната
                вештина за работење. Ние одиме и чекор понатаму од другите - со обуката на нашите
                клиенти ние сме во ситуација да обезбедиме подобра услуга, а со тоа и нашите клиенти
                се чувствуваат посигурно и покомфорно.
            </div>
            <div class="naslovAboutClients">
                Технички тим
            </div>
            <div class="tekstAboutUs">
                <img src="Images/SupportTeam.jpg" />
                &nbsp&nbsp&nbsp Нашиот технички тим обезбедува поддршка почнувајќи од проценка на
                потребите преку дизајнирање и инсталација на Вашиот компјутерски систем, до секојдневно
                сервисирање и советување. Ние ќе се грижиме за техничките детали така да Вие можете
                да работите без проблеми на постојан и сигурен компјутерски систем.
            </div>
        </div>
        <div id="partneri" class="tekst">
            <div class="naslovAboutClients">
                Светските брендови
            </div>
            <div class="tekstAboutUs">
                <img src="Images/BestBrands.jpg" />
                &nbsp&nbsp&nbsp Нашата команија е во тренд со светските брендови. Секогаш ви ги
                нудиме најдобрите решенија дирекно од најдобрите компании.
            </div>
            <div class="naslovAboutClients">
                Symbol-Motorola
            </div>
            <div class="tekstAboutUs">
                <img src="Images/SymbolLogo.jpg" />
                &nbsp&nbsp&nbsp <b>ИНФО Биро</b> е главен дистибутер на производите од <b>Symbol</b>
                за Република Македонија.Присутен на пазарот со баркод-скенери,мобилни уреди и инфо
                дисплеии.
            </div>
            <div class="partneriAboutSliki">
                <img src="Images/HPlogo.jpg" /><img src="Images/Msilogo.jpg" /><img src="Images/WDlogo.jpg" /><img
                    src="Images/Linksys.jpg" /><img src="Images/Microsoft.jpg" /><img src="Images/Samsunglogo.jpg" />
            </div>
        </div>
    </div>--%>
</asp:Content>