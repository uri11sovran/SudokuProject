using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuProjectOmega;

namespace SudokuTests
{
    [TestClass]
    public class SudokuTest
    {
        [TestMethod]
        public void Test1x1()
        {
            Assert.AreEqual(Program.Solve("0", 1), "1", "not equal");
            Assert.AreEqual(Program.Solve("1", 1), "1", "not equal");
            Assert.AreEqual(Program.Solve("a", 1), "Invalid input: all characters must be a valid in range sudoku characters...", "not equal");
        }

        [TestMethod]
        public void Test4x4()
        {
            Assert.AreEqual(Program.Solve("0000000000000000", 1), "1234341221434321", "not equal");
            Assert.AreEqual(Program.Solve("0010002000000000", 1), "2413132431424231", "not equal");
            Assert.AreEqual(Program.Solve("0011002000000000", 1), "Cannot solve this board due to invalid cell positioning...", "not equal");
        }

        [TestMethod]
        public void Test9x9()
        {
            Assert.AreEqual(Program.Solve("306508400520000000087000031003010080900863005050090600130000250000000074005206300", 1),
                "316578492529134768487629531263415987974863125851792643138947256692351874745286319", "not equal");
            Assert.AreEqual(Program.Solve("002501700600807009080204010007602500050000090004109200070305060500908007008706900", 1), 
                "942561783615837429783294615197682534256473198834159276479315862561928347328746951", "not equal");
            Assert.AreEqual(Program.Solve("000000000000000000000000000000000000000000000000000000000000000000000000000000000", 1),
                "123456789456789123789123456231674895875912364694538217317265948542897631968341572", "not equal");
        }

        [TestMethod]
        public void Test16x16()
        {
            Assert.AreEqual(Program.Solve("00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000" +
                "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000" +
                "00000000000000000000000000000000000000000000000", 1),
                "123456789:;<=>?@5678=>?@12349:;<9:;<1234=>?@5678=>?@9:;<56781234241389:5>;<6@?=7?;<>@4162=57839:7=@9>;2?83:164<585:6" +
                "37<=?@49;12>31826597;4@=:<>?<74=;?>1398:2@56>@9:4<=2651?378;6?5;:8@37<2>491=4861<35;:7>2?=@9:3=?7@89<165>;42;<>52=4:@?9378" +
                "61@927?16>48=;<5:3", "not equal");

            Assert.AreEqual(Program.Solve("00000000000000000000000000000000000000000000000000008000000000" +
                "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000" +
                "400000000000000060000000000000002000000500000050000000000000000000000000?00000000000000000000000000500000", 1),
                "4<=3:15;962@?8>758:@?26<7=4>193;92>?@37=51;86:<4176;849>3<:?@2=5<:@2;615?8=3749>>3?1<827" +
                "4@9:5;6=7458=93?<>6;2@1:69;=>:4@2517<3?8@5<>378:=2?946;12=875;<46:31>?@9:?149=>6@;<53782" +
                "3;961?@2>784:=5<?62<45;3:9>=817@=>792<:183@6;54?;@456>=81?729<:3813:7@?9;45<=>26", "not equal");

            Assert.AreEqual(Program.Solve("102300;680054<00>00;08:0<09007000<00000002700?090090070000:0>85" +
                ";0:0@1002;40600080300000900000000;942050>00=030000000008@3920040000100:?39600000000060900@" +
                "0<02;4>00000000200000102000@0>8100=<06054?10>0000600@0060@00250000000<000<00@0:0710=00400:>?00;43000501", 1), "Unsolvable board", "not equal");

            Assert.AreEqual(Program.Solve("040080@0;010060>30090?04:70=00<006002;0080003000?0000" +
                "00=00>002040008030070005000000000>0000:0@0=009250000800;000<010000@00=00030000" +
                "<?0000600=047@1=0:00300700900600000;04009002:03000@000>800;005;3:000800<400010>0" +
                "0;9000=?04050=040600000020<090<0@0=00010060?0", 1), 
                ":45=8<@9;213?67>32;9>?64:7@=15<816<>2;7:8?453=9@?8@7351=9<>6:2;4>=68<34?7@9;51:275" +
                "?316>;<42:9@8=4@925:=73861;?><<:1;982@?5=>7436;98<?25>16:@=347@1=5:4832;7<>96?67>?=1" +
                ";<4359@82:23:47@96=>8?<;155;3:@>?869<427=18>26;9<1@=?74:53=?416735>:;28<@99<7@4=:251386>?;", "not equal");

            Assert.AreEqual(Program.Solve("40080@0;010060>30090?04:70=00<006002;0080003000?0000" +
                "00=00>002040008030070005000000000>0000:0@0=009250000800;000<010000@00=00030000" +
                "<?0000600=047@1=0:00300700900600000;04009002:03000@000>800;005;3:000800<400010>0" +
                "0;9000=?04050=040600000020<090<0@0=00010060?0", 1),
                "Impossible board size...", "not equal");

            Assert.AreEqual(Program.Solve("", 1),
                "Invalid Board: empty board", "not equal");

            Assert.AreEqual(Program.Solve("0090104576;<=0?00700280040005:0<0<" +
                "00000015:=28390000000023984167000856009:<0>0@=130000000" +
                "2407<:600<0702030=189450=0004<0875632108103000:5<0@96=>056" +
                "00003=48:<72000000090>032:@5100>=000<69170483061530000879@=<40" +
                "0070004012365>800320>07<=65009:00009000:@>41372", 1), "289:134576;<" +
                "=>?@37=128694>@?5:;<4<?6>@7;15:=28395>;@<:?=23984167724856319:<;>?@" +
                "=135;=98?@24>7<:66:<>7;2@3?=189459=@?:4<>8756321;812347;:5<?@96=>;5" +
                "69@1>3=48:<72?<?746=98>;32:@51:@>=?25<6917;483>6153?:2;879@=<4=9:7;" +
                "<@4?12365>8@4328>17<=65?;9:?;8<95=6:@>41372");
        }
    }
}