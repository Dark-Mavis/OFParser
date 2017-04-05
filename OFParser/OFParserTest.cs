using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OFParser.Properties;

namespace OFParser
{
    [TestFixture]
    class OFParserTest
    {
        OFParser T20 = new OFParser(Encoding.UTF8.GetString(Resources.T20));
        OFParser T1 = new OFParser(Encoding.UTF8.GetString(Resources.T1));
        OFParser T385 = new OFParser(Encoding.UTF8.GetString(Resources.T385));
        [Test]
        public void T20BaseAndMiscDataTest()
        {
            Assert.AreEqual("16.01.00.0327.15", T20.Version);
            DateTime check = new DateTime(2017, 2, 9, 16, 34, 14);
            Assert.AreEqual(check, T20.DateAndTime);
            Assert.AreEqual("102815R-CDE", T20.JobKey);
            Assert.AreEqual("CLEARWATER II APARTMENTS", T20.JobDescription);
            Assert.AreEqual("PB-21", T20.TrussDescription);
            Assert.AreEqual("IBC 2012\\TPI 2007", T20.MiscDataBlock.DesignCode);
            Assert.AreEqual(false, T20.MiscDataBlock.IsFlameRetardant);
            Assert.AreEqual("Customer", T20.MiscDataBlock.MKAPriority);
            Assert.AreEqual(true, T20.MiscDataBlock.TCSheathingStatus);
        }
        [Test]
        public void T1BaseAndMiscDataTest()
        {
            Assert.AreEqual("K-H6", T1.TrussDescription);
            Assert.AreEqual("IBC 2012\\TPI 2007", T1.MiscDataBlock.DesignCode);
            Assert.AreEqual(false, T1.MiscDataBlock.IsFlameRetardant);
            Assert.AreEqual("Customer", T1.MiscDataBlock.MKAPriority);
            Assert.AreEqual(true, T1.MiscDataBlock.TCSheathingStatus);
            Assert.AreEqual(0, T1.MiscDataBlock.TCPurlinSpacing);
            Assert.AreEqual(0, T1.MiscDataBlock.BCPurlinSpacing);
            Assert.AreEqual("CLB", T1.MiscDataBlock.RequestedBraceType);
            Assert.AreEqual(true, T1.MiscDataBlock.LoadSharing);
            Assert.AreEqual(false, T1.MiscDataBlock.PlasterCeiling);
        }
        [Test]
        public void T385MiscDataTest()
        {
            Assert.AreEqual("None", T385.MiscDataBlock.SY42SquareCutWebCalcs);
            Assert.AreEqual(false, T385.MiscDataBlock.AllowBoltsOnGirders);
            Assert.AreEqual(false, T385.MiscDataBlock.SDSScrewsOnGirders);
            Assert.AreEqual("Auto", T385.MiscDataBlock.AllowScabsOnTrays);
            Assert.AreEqual(false, T385.MiscDataBlock.EmpiricalAnalysis);

            Assert.AreEqual(0, T385.MiscDataBlock.TCPurlinSpacing);
            Assert.AreEqual(0, T385.MiscDataBlock.BCPurlinSpacing);
            Assert.AreEqual("CLB", T385.MiscDataBlock.RequestedBraceType);
            Assert.AreEqual(true, T385.MiscDataBlock.LoadSharing);
            Assert.AreEqual(false, T385.MiscDataBlock.PlasterCeiling);
        }
        [Test]
        public void T20MiscAndJointDataTest()
        {
            Assert.AreEqual("None", T20.MiscDataBlock.SY42SquareCutWebCalcs);
            Assert.AreEqual(false, T20.MiscDataBlock.AllowBoltsOnGirders);
            Assert.AreEqual(false, T20.MiscDataBlock.SDSScrewsOnGirders);
            Assert.AreEqual("Auto", T20.MiscDataBlock.AllowScabsOnTrays);
            Assert.AreEqual(false, T20.MiscDataBlock.EmpiricalAnalysis);

            Assert.AreEqual(false, T20.MiscDataBlock.CompositeFloor);
            Assert.AreEqual(true, T20.MiscDataBlock.KmFactor);
            Assert.AreEqual(false, T20.MiscDataBlock.RigidInsertsAllowedForFullFc);
            Assert.AreEqual(false, T20.MiscDataBlock.PlateIncreaseFactorForOverstressedBrg);
            Assert.AreEqual(0.263, T20.JointDataBlock.Nodes[0].XCoord);
        }
        [Test]
        public void T1MiscAndJointDataTest()
        {
            Assert.AreEqual(29.938, T1.JointDataBlock.Nodes[1].YCoord);
            Assert.AreEqual(5, T1.JointDataBlock.Nodes[2].Description);
            Assert.AreEqual(6.406, T1.JointDataBlock.Nodes[3].XCoord);
            Assert.AreEqual(35.409, T1.JointDataBlock.Nodes[4].YCoord);
            Assert.AreEqual(5, T1.JointDataBlock.Nodes[5].Description);

            Assert.AreEqual(false, T1.MiscDataBlock.CompositeFloor);
            Assert.AreEqual(true, T1.MiscDataBlock.KmFactor);
            Assert.AreEqual(false, T1.MiscDataBlock.RigidInsertsAllowedForFullFc);
            Assert.AreEqual(false, T1.MiscDataBlock.PlateIncreaseFactorForOverstressedBrg);
            Assert.AreEqual(0, T1.JointDataBlock.Nodes[0].XCoord);
        }
        [Test]
        public void T385JointDataTest()
        {
            Assert.AreEqual(32.237, T385.JointDataBlock.Nodes[1].YCoord);
            Assert.AreEqual(46, T385.JointDataBlock.Nodes[2].Description);
            Assert.AreEqual(0.851, T385.JointDataBlock.Nodes[3].XCoord);
            Assert.AreEqual(32.309, T385.JointDataBlock.Nodes[4].YCoord);
            Assert.AreEqual(5, T385.JointDataBlock.Nodes[5].Description);

            Assert.AreEqual(1.844, T385.JointDataBlock.Nodes[6].XCoord);
            Assert.AreEqual(33.177, T385.JointDataBlock.Nodes[7].YCoord);
            Assert.AreEqual(26, T385.JointDataBlock.Nodes[8].Description);
            Assert.AreEqual(8.104, T385.JointDataBlock.Nodes[9].XCoord);
            Assert.AreEqual(33.117, T385.JointDataBlock.Nodes[10].YCoord);

        }
        [Test]
        public void T20JointDataTest()
        {
            Assert.AreEqual(26, T20.JointDataBlock.Nodes[11].Description);
            Assert.AreEqual(8.591, T20.JointDataBlock.Nodes[12].XCoord);
            Assert.AreEqual(39.797, T20.JointDataBlock.Nodes[13].YCoord);
            Assert.AreEqual(29, T20.JointDataBlock.Nodes[14].Description);
            Assert.AreEqual(13.518, T20.JointDataBlock.Nodes[15].XCoord);

            Assert.AreEqual(5.851, T20.JointDataBlock.Nodes[6].XCoord);
            Assert.AreEqual(43.289, T20.JointDataBlock.Nodes[7].YCoord);
            Assert.AreEqual(5, T20.JointDataBlock.Nodes[8].Description);
            Assert.AreEqual(5.997, T20.JointDataBlock.Nodes[9].XCoord);
            Assert.AreEqual(43.289, T20.JointDataBlock.Nodes[10].YCoord);

        }
        [Test]
        public void T1PlateInfoTest()
        {
            Assert.AreEqual("Standard", T1.PlateInfoBlock.ToothHoldingDescription);
            Assert.AreEqual(1, T1.PlateInfoBlock.ToothHoldingName);
            Assert.AreEqual(0, T1.PlateInfoBlock.NumberOfUnplatedJoints);
            Assert.AreEqual(1, T1.PlateInfoBlock.NumberOfTypes);
            Assert.AreEqual(18, T1.PlateInfoBlock.MostCommonPlateType);

            Assert.AreEqual("WAVE", T1.PlateInfoBlock.PlateTypeName);
            Assert.AreEqual(18, T1.PlateInfoBlock.PlateType);
            Assert.AreEqual(849.629, T1.PlateInfoBlock.ZeroTension);
            Assert.AreEqual(895.082, T1.PlateInfoBlock.NinetyTension);
            Assert.AreEqual(656.161, T1.PlateInfoBlock.ZeroShear);
        }
        [Test]
        public void T385PlateInfoAndPlateDataTest()
        {
            Assert.AreEqual(567.585, T385.PlateInfoBlock.NinetyShear);
            Assert.AreEqual(2, T385.PlateDataBlock.Plates[0].Node);
            Assert.AreEqual(18, T385.PlateDataBlock.Plates[1].Type);
            Assert.AreEqual("4X6", T385.PlateDataBlock.Plates[2].Name);
            Assert.AreEqual("N", T385.PlateDataBlock.Plates[3].Method);

            Assert.AreEqual("WAVE", T385.PlateInfoBlock.PlateTypeName);
            Assert.AreEqual(18, T385.PlateInfoBlock.PlateType);
            Assert.AreEqual(849.629, T385.PlateInfoBlock.ZeroTension);
            Assert.AreEqual(895.082, T385.PlateInfoBlock.NinetyTension);
            Assert.AreEqual(656.161, T385.PlateInfoBlock.ZeroShear);
        }
        [Test]
        public void T20PlateInfoDataTest()
        {
            Assert.AreEqual(3, T20.PlateDataBlock.Plates[0].Node);
            Assert.AreEqual(18, T20.PlateDataBlock.Plates[1].Type);
            Assert.AreEqual("4X6", T20.PlateDataBlock.Plates[2].Name);
            Assert.AreEqual("N", T20.PlateDataBlock.Plates[3].Method);
            Assert.AreEqual("On Face", T20.PlateDataBlock.Plates[4].Application);
            Assert.AreEqual(0.92, T20.PlateDataBlock.Plates[5].Cq);
            Assert.AreEqual(0.10, T20.PlateDataBlock.Plates[4].JSI);
        }
        [Test]
        public void T1PlateInfoDataTest()
        {
            Assert.AreEqual(0, T1.PlateDataBlock.Plates[0].Node);
            Assert.AreEqual(18, T1.PlateDataBlock.Plates[1].Type);
            Assert.AreEqual("1.5X4", T1.PlateDataBlock.Plates[2].Name);
            Assert.AreEqual("N", T1.PlateDataBlock.Plates[3].Method);
            Assert.AreEqual("On Face", T1.PlateDataBlock.Plates[4].Application);
            Assert.AreEqual(0.92, T1.PlateDataBlock.Plates[5].Cq);
            Assert.AreEqual(0.48, T1.PlateDataBlock.Plates[6].JSI);
        }
        [Test]
        public void T385PlateInfoDataTest()
        {
            Assert.AreEqual(2, T385.PlateDataBlock.Plates[0].Node);
            Assert.AreEqual(18, T385.PlateDataBlock.Plates[1].Type);
            Assert.AreEqual("4X6", T385.PlateDataBlock.Plates[2].Name);
            Assert.AreEqual("N", T385.PlateDataBlock.Plates[3].Method);
            Assert.AreEqual("On Face", T385.PlateDataBlock.Plates[4].Application);
            Assert.AreEqual(0.92, T385.PlateDataBlock.Plates[3].Cq);
            Assert.AreEqual(0.64, T385.PlateDataBlock.Plates[2].JSI);
        }
        [Test]
        public void T20QualityContTest()
        {
            Assert.AreEqual(8, T20.QualityControlToothCountsBlock.Joints[2].JointNumber);
            Assert.AreEqual("WAVE", T20.QualityControlToothCountsBlock.Joints[0].PlateType);
            Assert.AreEqual(4, T20.QualityControlToothCountsBlock.Joints[1].Teeths[0].MemberNumber);
            Assert.AreEqual(13, T20.QualityControlToothCountsBlock.Joints[2].Teeths[0].RequiredTeeth);
            Assert.AreEqual(59, T20.QualityControlToothCountsBlock.Joints[3].Teeths[0].AvailableTeeth);
            Assert.AreEqual(8, T20.QualityControlToothCountsBlock.Joints[4].Teeths[1].MemberNumber);
            Assert.AreEqual(10, T20.QualityControlToothCountsBlock.Joints[5].Teeths[1].RequiredTeeth);
            Assert.AreEqual(25, T20.QualityControlToothCountsBlock.Joints[4].Teeths[1].AvailableTeeth);
        }
        [Test]
        public void T1QualityContTest()
        {
            Assert.AreEqual("WAVE", T1.QualityControlToothCountsBlock.Joints[0].PlateType);
            Assert.AreEqual(8, T1.QualityControlToothCountsBlock.Joints[1].Teeths[0].MemberNumber);
            Assert.AreEqual(5, T1.QualityControlToothCountsBlock.Joints[2].Teeths[0].RequiredTeeth);
            Assert.AreEqual(97, T1.QualityControlToothCountsBlock.Joints[3].Teeths[0].AvailableTeeth);
            Assert.AreEqual(12, T1.QualityControlToothCountsBlock.Joints[4].Teeths[1].MemberNumber);
            Assert.AreEqual(10, T1.QualityControlToothCountsBlock.Joints[5].Teeths[1].RequiredTeeth);
            Assert.AreEqual(24, T1.QualityControlToothCountsBlock.Joints[6].Teeths[1].AvailableTeeth);
        }
        [Test]
        public void T385QualityContTest()
        {
            Assert.AreEqual("WAVE", T385.QualityControlToothCountsBlock.Joints[0].PlateType);
            Assert.AreEqual(4, T385.QualityControlToothCountsBlock.Joints[1].Teeths[0].MemberNumber);
            Assert.AreEqual(12, T385.QualityControlToothCountsBlock.Joints[2].Teeths[0].RequiredTeeth);
            Assert.AreEqual(32, T385.QualityControlToothCountsBlock.Joints[3].Teeths[0].AvailableTeeth);
            Assert.AreEqual(3, T385.QualityControlToothCountsBlock.Joints[4].Teeths[1].MemberNumber);
            Assert.AreEqual(3, T385.QualityControlToothCountsBlock.Joints[3].Teeths[1].RequiredTeeth);
            Assert.AreEqual(38, T385.QualityControlToothCountsBlock.Joints[2].Teeths[1].AvailableTeeth);
        }
        [Test]
        public void T20MemberDataTest()
        {
            Assert.AreEqual(0, T20.MemberDataBlock.Members[0].NegativeJoint);
            Assert.AreEqual(0, T20.MemberDataBlock.Members[1].NegEndFix);
            Assert.AreEqual(11, T20.MemberDataBlock.Members[2].PositiveJoint);
            Assert.AreEqual(0, T20.MemberDataBlock.Members[3].PosEndFix);
            Assert.AreEqual(Type.Roll, T20.MemberDataBlock.Members[4].Type);
            Assert.AreEqual(3, T20.MemberDataBlock.Members[5].AssociatedPieceNumber);
            Assert.AreEqual(7, T20.MemberDataBlock.Members[6].LumberNumber);
            Assert.AreEqual(-1, T20.MemberDataBlock.Members[7].PurlinSpacingInches);
        }
        [Test]
        public void T1MemberDataTest()
        {
            Assert.AreEqual(0, T1.MemberDataBlock.Members[0].NegativeJoint);
            Assert.AreEqual(0, T1.MemberDataBlock.Members[1].NegEndFix);
            Assert.AreEqual(6, T1.MemberDataBlock.Members[2].PositiveJoint);
            Assert.AreEqual(0, T1.MemberDataBlock.Members[3].PosEndFix);
            Assert.AreEqual(Type.Roll, T1.MemberDataBlock.Members[4].Type);
            Assert.AreEqual(1, T1.MemberDataBlock.Members[5].AssociatedPieceNumber);
            Assert.AreEqual(8, T1.MemberDataBlock.Members[6].LumberNumber);
            Assert.AreEqual(0, T1.MemberDataBlock.Members[7].PurlinSpacingInches);
        }
        [Test]
        public void T385MemberDataTest()
        {
            Assert.AreEqual(3, T385.MemberDataBlock.Members[0].NegativeJoint);
            Assert.AreEqual(0, T385.MemberDataBlock.Members[1].NegEndFix);
            Assert.AreEqual(5, T385.MemberDataBlock.Members[2].PositiveJoint);
            Assert.AreEqual(0, T385.MemberDataBlock.Members[3].PosEndFix);
            Assert.AreEqual(Type.Roll, T385.MemberDataBlock.Members[4].Type);
            Assert.AreEqual(4, T385.MemberDataBlock.Members[5].AssociatedPieceNumber);
            Assert.AreEqual(17, T385.MemberDataBlock.Members[6].LumberNumber);
            Assert.AreEqual(0, T385.MemberDataBlock.Members[7].PurlinSpacingInches);
        }
        [Test]
        public void T20LumberDataTest()
        {
            Assert.AreEqual(7, T20.LumberDataBlock.Lumbers[0].Grade);
            Assert.AreEqual(3.50, T20.LumberDataBlock.Lumbers[1].DepthInches);
            Assert.AreEqual(1.50, T20.LumberDataBlock.Lumbers[2].ThickInches);
            Assert.AreEqual("STACKED CHORD FICT MEMBER", T20.LumberDataBlock.Lumbers[3].Description);
            Assert.AreEqual(1000000, T20.LumberDataBlock.Lumbers[2].EPSI);
            Assert.AreEqual(1100, T20.LumberDataBlock.Lumbers[1].FbPSI);
            Assert.AreEqual(850, T20.LumberDataBlock.Lumbers[0].FcPSI);
            Assert.AreEqual(675, T20.LumberDataBlock.Lumbers[1].FtPSI);
            Assert.AreEqual(0, T20.LumberDataBlock.Lumbers[2].FcpPSI);
            Assert.AreEqual(0, T20.LumberDataBlock.Lumbers[3].FvPSI);
            Assert.AreEqual(MSR.F, T20.LumberDataBlock.Lumbers[2].MSR);
            Assert.AreEqual(CW.CW, T20.LumberDataBlock.Lumbers[1].CW);
            Assert.AreEqual("2x4", T20.LumberDataBlock.Lumbers[0].SizeName);
        }
        [Test]
        public void T1LumberDataTest()
        {
            Assert.AreEqual(7, T1.LumberDataBlock.Lumbers[0].Grade);
            Assert.AreEqual(3.50, T1.LumberDataBlock.Lumbers[1].DepthInches);
            Assert.AreEqual(1.50, T1.LumberDataBlock.Lumbers[2].ThickInches);
            Assert.AreEqual("STACKED CHORD FICT MEMBER", T1.LumberDataBlock.Lumbers[3].Description);
            Assert.AreEqual(1000000, T1.LumberDataBlock.Lumbers[2].EPSI);
            Assert.AreEqual(1500, T1.LumberDataBlock.Lumbers[1].FbPSI);
            Assert.AreEqual(850, T1.LumberDataBlock.Lumbers[0].FcPSI);
            Assert.AreEqual(1000, T1.LumberDataBlock.Lumbers[1].FtPSI);
            Assert.AreEqual(0, T1.LumberDataBlock.Lumbers[2].FcpPSI);
            Assert.AreEqual(0, T1.LumberDataBlock.Lumbers[3].FvPSI);
            Assert.AreEqual(MSR.F, T1.LumberDataBlock.Lumbers[2].MSR);
            Assert.AreEqual(CW.CW, T1.LumberDataBlock.Lumbers[1].CW);
            Assert.AreEqual("2x4", T1.LumberDataBlock.Lumbers[0].SizeName);
        }
        [Test]
        public void T385LumberDataTest()
        {
            Assert.AreEqual(7, T385.LumberDataBlock.Lumbers[0].Grade);
            Assert.AreEqual(3.50, T385.LumberDataBlock.Lumbers[1].DepthInches);
            Assert.AreEqual(1.50, T385.LumberDataBlock.Lumbers[2].ThickInches);
            Assert.AreEqual("STACKED CHORD FICT MEMBER", T385.LumberDataBlock.Lumbers[3].Description);
            Assert.AreEqual(1000000, T385.LumberDataBlock.Lumbers[2].EPSI);
            Assert.AreEqual(1100, T385.LumberDataBlock.Lumbers[1].FbPSI);
            Assert.AreEqual(850, T385.LumberDataBlock.Lumbers[0].FcPSI);
            Assert.AreEqual(675, T385.LumberDataBlock.Lumbers[1].FtPSI);
            Assert.AreEqual(0, T385.LumberDataBlock.Lumbers[2].FcpPSI);
            Assert.AreEqual(0, T385.LumberDataBlock.Lumbers[3].FvPSI);
            Assert.AreEqual(MSR.F, T385.LumberDataBlock.Lumbers[2].MSR);
            Assert.AreEqual(CW.CW, T385.LumberDataBlock.Lumbers[1].CW);
            Assert.AreEqual("2x4", T385.LumberDataBlock.Lumbers[0].SizeName);
        }
        [Test]
        public void T20BearingDataTest()
        {
            Assert.AreEqual(0, T20.BearingDataBlock.Bearings[0].Joints[0].JointNumber);
            Assert.AreEqual(Type.Pin, T20.BearingDataBlock.Bearings[0].Joints[0].Type);
            Assert.AreEqual(1.594, T20.BearingDataBlock.Bearings[1].WidthInches);
            Assert.AreEqual(0, T20.BearingDataBlock.Bearings[0].XCoord);
            Assert.AreEqual(39.651, T20.BearingDataBlock.Bearings[1].YCoord);
            Assert.AreEqual(2, T20.BearingDataBlock.Bearings[0].BearingType);
            Assert.AreEqual("Rigid Surface", T20.BearingDataBlock.Bearings[1].WallSpecies);
            Assert.AreEqual(99.000, T20.BearingDataBlock.MaxProtrusionOfSupportingFastener);
            Assert.AreEqual(false, T20.BearingDataBlock.OnlyFastenersGreaterThanOnePointFiveInchesInMultiPlySupportingMember);
        }
        [Test]
        public void T1BearingDataTest()
        {
            Assert.AreEqual(1, T1.BearingDataBlock.Bearings[0].Joints[0].JointNumber);
            Assert.AreEqual(Type.Pin, T1.BearingDataBlock.Bearings[0].Joints[0].Type);
            Assert.AreEqual(1.500, T1.BearingDataBlock.Bearings[1].WidthInches);
            Assert.AreEqual(0, T1.BearingDataBlock.Bearings[0].XCoord);
            Assert.AreEqual(29.792, T1.BearingDataBlock.Bearings[1].YCoord);
            Assert.AreEqual(2, T1.BearingDataBlock.Bearings[0].BearingType);
            Assert.AreEqual("Rigid Surface", T1.BearingDataBlock.Bearings[1].WallSpecies);
            Assert.AreEqual(99.000, T1.BearingDataBlock.MaxProtrusionOfSupportingFastener);
            Assert.AreEqual(false, T1.BearingDataBlock.OnlyFastenersGreaterThanOnePointFiveInchesInMultiPlySupportingMember);
        }
        [Test]
        public void T385BearingDataTest()
        {
            Assert.AreEqual(2, T385.BearingDataBlock.Bearings[0].Joints[1].JointNumber);
            Assert.AreEqual(Type.Roll, T385.BearingDataBlock.Bearings[0].Joints[2].Type);
            Assert.AreEqual(1.500, T385.BearingDataBlock.Bearings[0].WidthInches);
            Assert.AreEqual(0, T385.BearingDataBlock.Bearings[0].XCoord);
            Assert.AreEqual(32.163, T385.BearingDataBlock.Bearings[0].YCoord);
            Assert.AreEqual(2, T385.BearingDataBlock.Bearings[0].BearingType);
            Assert.AreEqual("Rigid Surface", T385.BearingDataBlock.Bearings[0].WallSpecies);
            Assert.AreEqual(99.000, T385.BearingDataBlock.MaxProtrusionOfSupportingFastener);
            Assert.AreEqual(false, T385.BearingDataBlock.OnlyFastenersGreaterThanOnePointFiveInchesInMultiPlySupportingMember);
        }

        [Test]
        public void T20Case1LoadingDataTest()
        {
            Assert.AreEqual("STD.AUTO.LOAD", T20.LoadCases[1].LoadCaseType);
            Assert.AreEqual(2.00, T20.LoadCases[1].SpacingFeet);
            Assert.AreEqual(1.25, T20.LoadCases[1].DurationFactor);
            Assert.AreEqual(1.25, T20.LoadCases[1].PlateDurationFactor);
            Assert.AreEqual(1, T20.LoadCases[1].NumberOfPlys);
            Assert.AreEqual(false, T20.LoadCases[1].UserModifiedLoads);
            Assert.AreEqual(1, T20.LoadCases[1].KindOfLoadCase);
            Assert.AreEqual(true, T20.LoadCases[1].RepetitiveFactorsUsed);
            Assert.AreEqual(2.00, T20.LoadCases[1].SoffitDeadLoadPSF);
        }
        [Test]
        public void T1Case2UniformLoadsTest()
        {
            Assert.AreEqual(0, T1.LoadCases[2].UniformLoadsBlock.Loads[0].StartXFeet);
            Assert.AreEqual(38.55, T1.LoadCases[2].UniformLoadsBlock.Loads[1].StartYFeet);
            Assert.AreEqual(4.0, T1.LoadCases[2].UniformLoadsBlock.Loads[2].MagnitudeStartPLF);
            Assert.AreEqual(15.19, T1.LoadCases[2].UniformLoadsBlock.Loads[3].EndXFeet);
            Assert.AreEqual(24.79, T1.LoadCases[2].UniformLoadsBlock.Loads[2].EndYFeet);
            Assert.AreEqual(7.7, T1.LoadCases[2].UniformLoadsBlock.Loads[1].MagnitudeEndPLF);
            Assert.AreEqual(false, T1.LoadCases[2].UniformLoadsBlock.Loads[0].LiveLoad);
        }
        [Test]
        public void T385Case3ReactionDataTest()
        {
            Assert.AreEqual(0, T385.LoadCases[3].ReactionDataBlock.Bearings[0].BearingNumber);
            Assert.AreEqual(242.105, T385.LoadCases[3].ReactionDataBlock.Bearings[1].VerticalReactionPounds);
            Assert.AreEqual(32575.76, T385.LoadCases[3].ReactionDataBlock.Bearings[2].VerticalAllowablePounds);
            Assert.AreEqual(-0.00, T385.LoadCases[3].ReactionDataBlock.Bearings[1].HorizontalPounds);
            Assert.AreEqual(0.00, T385.LoadCases[3].ReactionDataBlock.Bearings[0].MomentFtPound);
            Assert.AreEqual(1234567890, T385.LoadCases[3].ReactionDataBlock.Bearings[1].XLocation);
            Assert.AreEqual(1234567890, T385.LoadCases[3].ReactionDataBlock.Bearings[2].YLocation);
        }
        [Test]
        public void T20Case4CSIDataTest()
        {
            Assert.AreEqual(0.015, T20.LoadCases[4].CSIDataBlock.Members[0].AX);
            Assert.AreEqual(0.147, T20.LoadCases[4].CSIDataBlock.Members[1].BD);
            Assert.AreEqual(0.062, T20.LoadCases[4].CSIDataBlock.Members[2].Total);
            Assert.AreEqual(10.85, T20.LoadCases[4].CSIDataBlock.Members[3].LocMaxFeet);
            Assert.AreEqual(56.41, T20.LoadCases[4].CSIDataBlock.Members[4].LenInches);
            Assert.AreEqual(0.7408, T20.LoadCases[4].CSIDataBlock.Members[5].Ke);
            Assert.AreEqual(1.00, T20.LoadCases[4].CSIDataBlock.Members[6].RAF);
            Assert.AreEqual(1.00, T20.LoadCases[4].CSIDataBlock.Members[7].RBF);
        }
        [Test]
        public void T1Case5CSIShearDataTest()
        {
            Assert.AreEqual(26.44, T1.LoadCases[5].CSIShearDataBlock.Members[0].Actual);
            Assert.AreEqual(219, T1.LoadCases[5].CSIShearDataBlock.Members[1].Allowable);
            Assert.AreEqual(0.061, T1.LoadCases[5].CSIShearDataBlock.Members[2].Csi);
            Assert.AreEqual(182.250, T1.LoadCases[5].CSIShearDataBlock.Members[3].Location);
        }
        [Test]
        public void T385Case6DeflectionPPDataTest()
        {
            Assert.AreEqual("PB", T385.LoadCases[6].DeflectionPPDataBlock.Deflects[0].Label);
            Assert.AreEqual(0.15, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[1].XLocationFeet);
            Assert.AreEqual(-0.00, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[2].LiveLoadXInches);
            Assert.AreEqual(-0.00, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[3].LiveLoadYInches);
            Assert.AreEqual(0.27, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[4].Allow);
            Assert.AreEqual(-0.00, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[5].DeadLoadXInches);
            Assert.AreEqual(0.00, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[6].DeadLoadYInches);
            Assert.AreEqual(0.00, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[7].TotalLoadXInches);
            Assert.AreEqual(0.00, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[6].TotalLoadYInches);
            Assert.AreEqual(0.40, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[5].AllowTotal);
            Assert.AreEqual(7.96, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[4].SpanFeet);
        }
        [Test]
        public void T20Case7DeflectionMPDataTest()
        {
            Assert.AreEqual("TC", T20.LoadCases[7].DeflectionMPDataBlock.Deflects[0].Label);
            Assert.AreEqual(3.74, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[1].XLocationFeet);
            Assert.AreEqual(0.00, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[2].LiveLoadXInches);
            Assert.AreEqual(0.03, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[3].LiveLoadYInches);
            Assert.AreEqual(0.24, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[4].Allow);
            Assert.AreEqual(0.00, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[5].DeadLoadXInches);
            Assert.AreEqual(0.04, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[6].DeadLoadYInches);
            Assert.AreEqual(0.00, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[7].TotalLoadXInches);
            Assert.AreEqual(-0.00, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[8].TotalLoadYInches);
            Assert.AreEqual(0.03, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[9].AllowTotal);
            Assert.AreEqual(0.29, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[10].SpanFeet);
        }
        [Test]
        public void T1Case8ForceDataTest()
        {
            Assert.AreEqual(341.97, T1.LoadCases[8].ForceDataBlock.Members[0].NegativeEndAxialPounds);
            Assert.AreEqual(208.03, T1.LoadCases[8].ForceDataBlock.Members[1].NegativeEndShearPounds);
            Assert.AreEqual(1304.22, T1.LoadCases[8].ForceDataBlock.Members[2].NegativeMomentPounds);
            Assert.AreEqual(0.00, T1.LoadCases[8].ForceDataBlock.Members[3].PositiveEndAxialPounds);
            Assert.AreEqual(76.77, T1.LoadCases[8].ForceDataBlock.Members[4].PositiveEndShearPounds);
            Assert.AreEqual(-564.56, T1.LoadCases[8].ForceDataBlock.Members[5].PositiveMomentPounds);
        }

        [Test]
        public void T385Case10LoadingDataTest()
        {
            Assert.AreEqual("MWFRS ASCE Perp/R+-", T385.LoadCases[10].LoadCaseType);
            Assert.AreEqual(2.00, T385.LoadCases[10].SpacingFeet);
            Assert.AreEqual(1.60, T385.LoadCases[10].DurationFactor);
            Assert.AreEqual(1.60, T385.LoadCases[10].PlateDurationFactor);
            Assert.AreEqual(1, T385.LoadCases[10].NumberOfPlys);
            Assert.AreEqual(false, T385.LoadCases[10].UserModifiedLoads);
            Assert.AreEqual(6, T385.LoadCases[10].KindOfLoadCase);
            Assert.AreEqual(true, T385.LoadCases[10].RepetitiveFactorsUsed);
            Assert.AreEqual(2.00, T385.LoadCases[10].SoffitDeadLoadPSF);
        }
        [Test]
        public void T20Case11UniformLoadsTest()
        {
            Assert.AreEqual(0, T20.LoadCases[11].UniformLoadsBlock.Loads[0].StartXFeet);
            Assert.AreEqual(46.52, T20.LoadCases[11].UniformLoadsBlock.Loads[1].StartYFeet);
            Assert.AreEqual(24.0, T20.LoadCases[11].UniformLoadsBlock.Loads[2].MagnitudeStartPLF);
            Assert.AreEqual(8.59, T20.LoadCases[11].UniformLoadsBlock.Loads[3].EndXFeet);
            Assert.AreEqual(46.52, T20.LoadCases[11].UniformLoadsBlock.Loads[4].EndYFeet);
            Assert.AreEqual(20, T20.LoadCases[11].UniformLoadsBlock.Loads[5].MagnitudeEndPLF);
            Assert.AreEqual(true, T20.LoadCases[11].UniformLoadsBlock.Loads[4].LiveLoad);
        }
        [Test]
        public void T1Case12ReactionDataTest()
        {
            Assert.AreEqual(1, T1.LoadCases[12].ReactionDataBlock.Bearings[0].BearingNumber);
            Assert.AreEqual(-245.441, T1.LoadCases[12].ReactionDataBlock.Bearings[1].VerticalReactionPounds);
            Assert.AreEqual(999999, T1.LoadCases[12].ReactionDataBlock.Bearings[0].VerticalAllowablePounds);
            Assert.AreEqual(0, T1.LoadCases[12].ReactionDataBlock.Bearings[1].HorizontalPounds);
            Assert.AreEqual(0, T1.LoadCases[12].ReactionDataBlock.Bearings[0].MomentFtPound);
            Assert.AreEqual(12.44, T1.LoadCases[12].ReactionDataBlock.Bearings[1].XLocation);
            Assert.AreEqual(29.79, T1.LoadCases[12].ReactionDataBlock.Bearings[0].YLocation);
        }
        [Test]
        public void T385Case13CSIDataTest()
        {
            Assert.AreEqual(7, T385.LoadCases[13].CSIDataBlock.Members[6].MemberNumber);
            Assert.AreEqual(0, T385.LoadCases[13].CSIDataBlock.Members[0].AX);
            Assert.AreEqual(0.023, T385.LoadCases[13].CSIDataBlock.Members[1].BD);
            Assert.AreEqual(0.020, T385.LoadCases[13].CSIDataBlock.Members[2].Total);
            Assert.AreEqual(1.7, T385.LoadCases[13].CSIDataBlock.Members[3].LocMaxFeet);
            Assert.AreEqual(7.29, T385.LoadCases[13].CSIDataBlock.Members[4].LenInches);
            Assert.AreEqual(.731, T385.LoadCases[13].CSIDataBlock.Members[5].Ke);
            Assert.AreEqual(1.1, T385.LoadCases[13].CSIDataBlock.Members[6].RAF);
            Assert.AreEqual(1.15, T385.LoadCases[13].CSIDataBlock.Members[7].RBF);
        }
        [Test]
        public void T20Case14CSIShearDataTest()
        {
            Assert.AreEqual(20.20, T20.LoadCases[14].CSIShearDataBlock.Members[0].Actual);
            Assert.AreEqual(280, T20.LoadCases[14].CSIShearDataBlock.Members[1].Allowable);
            Assert.AreEqual(0.003, T20.LoadCases[14].CSIShearDataBlock.Members[2].Csi);
            Assert.AreEqual(162.218, T20.LoadCases[14].CSIShearDataBlock.Members[3].Location);
        }
        [Test]
        public void T1Case15DeflectionPPDataTest()
        {
            Assert.AreEqual("PT", T1.LoadCases[15].DeflectionPPDataBlock.Deflects[0].Label);
            Assert.AreEqual(0, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[1].XLocationFeet);
            Assert.AreEqual(0, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[2].LiveLoadXInches);
            Assert.AreEqual(-0.01, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[3].LiveLoadYInches);
            Assert.AreEqual(.42, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[4].Allow);
            Assert.AreEqual(0, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[5].DeadLoadXInches);
            Assert.AreEqual(-0.02, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[6].DeadLoadYInches);
            Assert.AreEqual(0, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[7].TotalLoadXInches);
            Assert.AreEqual(-0.02, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[8].TotalLoadYInches);
            Assert.AreEqual(.25, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[9].AllowTotal);
            Assert.AreEqual(.29, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[8].SpanFeet);
        }
        [Test]
        public void T385Case16DeflectionMPDataTest()
        {
            Assert.AreEqual("TC", T385.LoadCases[16].DeflectionMPDataBlock.Deflects[0].Label);
            Assert.AreEqual(4.97, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[1].XLocationFeet);
            Assert.AreEqual(0.00, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[2].LiveLoadXInches);
            Assert.AreEqual(0.02, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[3].LiveLoadYInches);
            Assert.AreEqual(0.05, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[4].Allow);
            Assert.AreEqual(0.00, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[5].DeadLoadXInches);
            Assert.AreEqual(0.00, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[4].DeadLoadYInches);
            Assert.AreEqual(0.00, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[3].TotalLoadXInches);
            Assert.AreEqual(0.00, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[2].TotalLoadYInches);
            Assert.AreEqual(0.63, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[1].AllowTotal);
            Assert.AreEqual(1.16, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[0].SpanFeet);
        }
        [Test]
        public void T20Case17ForceDataTest()
        {
            Assert.AreEqual(159.78, T20.LoadCases[17].ForceDataBlock.Members[0].NegativeEndAxialPounds);
            Assert.AreEqual(-47.01, T20.LoadCases[17].ForceDataBlock.Members[1].NegativeEndShearPounds);
            Assert.AreEqual(-2.10, T20.LoadCases[17].ForceDataBlock.Members[2].NegativeMomentPounds);
            Assert.AreEqual(-19.21, T20.LoadCases[17].ForceDataBlock.Members[3].PositiveEndAxialPounds);
            Assert.AreEqual(-13.16, T20.LoadCases[17].ForceDataBlock.Members[4].PositiveEndShearPounds);
            Assert.AreEqual(-60.94, T20.LoadCases[17].ForceDataBlock.Members[5].PositiveMomentPounds);
        }

        [Test]
        public void T1Case18LoadingDataTest()
        {
            Assert.AreEqual("MWFRS ASCE Parl+-", T1.LoadCases[18].LoadCaseType);
            Assert.AreEqual(2.00, T1.LoadCases[18].SpacingFeet);
            Assert.AreEqual(1.60, T1.LoadCases[18].DurationFactor);
            Assert.AreEqual(1.60, T1.LoadCases[18].PlateDurationFactor);
            Assert.AreEqual(1, T1.LoadCases[18].NumberOfPlys);
            Assert.AreEqual(false, T1.LoadCases[18].UserModifiedLoads);
            Assert.AreEqual(6, T1.LoadCases[18].KindOfLoadCase);
            Assert.AreEqual(true, T1.LoadCases[18].RepetitiveFactorsUsed);
            Assert.AreEqual(2.00, T1.LoadCases[18].SoffitDeadLoadPSF);
        }
        [Test]
        public void T385Case19ExtraInfoTest()
        {
            Assert.AreEqual("ASCE 7-10 Wind Type Load Case", T385.LoadCases[19].ExtraInfoBlock.LoadCaseName);
            Assert.AreEqual("B", T385.LoadCases[19].ExtraInfoBlock.ExposureType);
            Assert.AreEqual("Residence", T385.LoadCases[19].ExtraInfoBlock.BuildingClass);
            Assert.AreEqual(142, T385.LoadCases[19].ExtraInfoBlock.WindSpeedMPH);
            Assert.AreEqual("Closed", T385.LoadCases[19].ExtraInfoBlock.BuildingType);
            Assert.AreEqual(4.2, T385.LoadCases[19].ExtraInfoBlock.DLTopPSF);
            Assert.AreEqual(1.8, T385.LoadCases[19].ExtraInfoBlock.DLBottomPSF);
            Assert.AreEqual(32.93, T385.LoadCases[19].ExtraInfoBlock.HeightFt);
            Assert.AreEqual(true, T385.LoadCases[19].ExtraInfoBlock.Ceiling);
            Assert.AreEqual(true, T385.LoadCases[19].ExtraInfoBlock.Zone1);
            Assert.AreEqual(false, T385.LoadCases[19].ExtraInfoBlock.Zone2);
            Assert.AreEqual(275, T385.LoadCases[19].ExtraInfoBlock.Uplifts1);
            Assert.AreEqual(1234567890, T385.LoadCases[19].ExtraInfoBlock.Uplifts2);
        }
        [Test]
        public void T20Case20UniformLoadsTest()
        {
            Assert.AreEqual(0.77, T20.LoadCases[20].UniformLoadsBlock.Loads[0].StartXFeet);
            Assert.AreEqual(39.53, T20.LoadCases[20].UniformLoadsBlock.Loads[1].StartYFeet);
            Assert.AreEqual(10.1, T20.LoadCases[20].UniformLoadsBlock.Loads[2].MagnitudeStartPLF);
            Assert.AreEqual(0.77, T20.LoadCases[20].UniformLoadsBlock.Loads[3].EndXFeet);
            Assert.AreEqual(46.52, T20.LoadCases[20].UniformLoadsBlock.Loads[4].EndYFeet);
            Assert.AreEqual(10.1, T20.LoadCases[20].UniformLoadsBlock.Loads[5].MagnitudeEndPLF);
            Assert.AreEqual(true, T20.LoadCases[20].UniformLoadsBlock.Loads[6].LiveLoad);
        }
        [Test]
        public void T1Case21ReactionDataTest()
        {
            Assert.AreEqual(1, T1.LoadCases[21].ReactionDataBlock.Bearings[0].BearingNumber);
            Assert.AreEqual(368.036, T1.LoadCases[21].ReactionDataBlock.Bearings[1].VerticalReactionPounds);
            Assert.AreEqual(4661.23, T1.LoadCases[21].ReactionDataBlock.Bearings[0].VerticalAllowablePounds);
            Assert.AreEqual(0, T1.LoadCases[21].ReactionDataBlock.Bearings[1].HorizontalPounds);
            Assert.AreEqual(0, T1.LoadCases[21].ReactionDataBlock.Bearings[0].MomentFtPound);
            Assert.AreEqual(12.44, T1.LoadCases[21].ReactionDataBlock.Bearings[1].XLocation);
            Assert.AreEqual(29.79, T1.LoadCases[21].ReactionDataBlock.Bearings[0].YLocation);
        }
        [Test]
        public void T385Case22CSIDataTest()
        {
            Assert.AreEqual(0, T385.LoadCases[22].CSIDataBlock.Members[0].AX);
            Assert.AreEqual(0.125, T385.LoadCases[22].CSIDataBlock.Members[1].BD);
            Assert.AreEqual(0.166, T385.LoadCases[22].CSIDataBlock.Members[2].Total);
            Assert.AreEqual(1.7, T385.LoadCases[22].CSIDataBlock.Members[3].LocMaxFeet);
            Assert.AreEqual(7.29, T385.LoadCases[22].CSIDataBlock.Members[4].LenInches);
            Assert.AreEqual(.731, T385.LoadCases[22].CSIDataBlock.Members[5].Ke);
            Assert.AreEqual(1.1, T385.LoadCases[22].CSIDataBlock.Members[6].RAF);
            Assert.AreEqual(1.15, T385.LoadCases[22].CSIDataBlock.Members[7].RBF);
        }
        [Test]
        public void T20Case23CSIShearDataTest()
        {
            Assert.AreEqual(46.12, T20.LoadCases[23].CSIShearDataBlock.Members[0].Actual);
            Assert.AreEqual(280, T20.LoadCases[23].CSIShearDataBlock.Members[1].Allowable);
            Assert.AreEqual(0.039, T20.LoadCases[23].CSIShearDataBlock.Members[2].Csi);
            Assert.AreEqual(162.218, T20.LoadCases[23].CSIShearDataBlock.Members[3].Location);
        }
        [Test]
        public void T1Case24DeflectionPPDataTest()
        {
            Assert.AreEqual("PT", T1.LoadCases[24].DeflectionPPDataBlock.Deflects[0].Label);
            Assert.AreEqual(0, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[1].XLocationFeet);
            Assert.AreEqual(0, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[2].LiveLoadXInches);
            Assert.AreEqual(0, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[3].LiveLoadYInches);
            Assert.AreEqual(.42, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[4].Allow);
            Assert.AreEqual(0, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[5].DeadLoadXInches);
            Assert.AreEqual(0.09, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[6].DeadLoadYInches);
            Assert.AreEqual(0, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[7].TotalLoadXInches);
            Assert.AreEqual(0.02, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[8].TotalLoadYInches);
            Assert.AreEqual(.25, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[9].AllowTotal);
            Assert.AreEqual(.29, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[8].SpanFeet);
        }
        [Test]
        public void T385Case25ForceDataTest()
        {
            Assert.AreEqual(-27.78, T385.LoadCases[25].ForceDataBlock.Members[0].NegativeEndAxialPounds);
            Assert.AreEqual(-168.14, T385.LoadCases[25].ForceDataBlock.Members[1].NegativeEndShearPounds);
            Assert.AreEqual(54.42, T385.LoadCases[25].ForceDataBlock.Members[2].NegativeMomentPounds);
            Assert.AreEqual(-34.03, T385.LoadCases[25].ForceDataBlock.Members[3].PositiveEndAxialPounds);
            Assert.AreEqual(0.00, T385.LoadCases[25].ForceDataBlock.Members[4].PositiveEndShearPounds);
            Assert.AreEqual(-12.60, T385.LoadCases[25].ForceDataBlock.Members[5].PositiveMomentPounds);
        }

        [Test]
        public void T20Case27LoadingDataTest()
        {
            Assert.AreEqual("MWFRS ASCE PrpD/L--", T20.LoadCases[27].LoadCaseType);
            Assert.AreEqual(2.00, T20.LoadCases[27].SpacingFeet);
            Assert.AreEqual(1.60, T20.LoadCases[27].DurationFactor);
            Assert.AreEqual(1.60, T20.LoadCases[27].PlateDurationFactor);
            Assert.AreEqual(1, T20.LoadCases[27].NumberOfPlys);
            Assert.AreEqual(false, T20.LoadCases[27].UserModifiedLoads);
            Assert.AreEqual(6, T20.LoadCases[27].KindOfLoadCase);
            Assert.AreEqual(true, T20.LoadCases[27].RepetitiveFactorsUsed);
            Assert.AreEqual(2.00, T20.LoadCases[27].SoffitDeadLoadPSF);
        }
        [Test]
        public void T1Case28ExtraInfoTest()
        {
            Assert.AreEqual("ASCE 7-10 Wind Type Load Case", T1.LoadCases[28].ExtraInfoBlock.LoadCaseName);
            Assert.AreEqual("B", T1.LoadCases[28].ExtraInfoBlock.ExposureType);
            Assert.AreEqual("Residence", T1.LoadCases[28].ExtraInfoBlock.BuildingClass);
            Assert.AreEqual(142, T1.LoadCases[28].ExtraInfoBlock.WindSpeedMPH);
            Assert.AreEqual("Closed", T1.LoadCases[28].ExtraInfoBlock.BuildingType);
            Assert.AreEqual(4.2, T1.LoadCases[28].ExtraInfoBlock.DLTopPSF);
            Assert.AreEqual(1.8, T1.LoadCases[28].ExtraInfoBlock.DLBottomPSF);
            Assert.AreEqual(35.55, T1.LoadCases[28].ExtraInfoBlock.HeightFt);
            Assert.AreEqual(true, T1.LoadCases[28].ExtraInfoBlock.Ceiling);
            Assert.AreEqual(true, T1.LoadCases[28].ExtraInfoBlock.Zone1);
            Assert.AreEqual(false, T1.LoadCases[28].ExtraInfoBlock.Zone2);
            Assert.AreEqual(230, T1.LoadCases[28].ExtraInfoBlock.Uplifts1);
            Assert.AreEqual(423, T1.LoadCases[28].ExtraInfoBlock.Uplifts2);
        }
        [Test]
        public void T385Case29UniformLoadsTest()
        {
            Assert.AreEqual(1.84, T385.LoadCases[29].UniformLoadsBlock.Loads[0].StartXFeet);
            Assert.AreEqual(32.20, T385.LoadCases[29].UniformLoadsBlock.Loads[1].StartYFeet);
            Assert.AreEqual(24, T385.LoadCases[29].UniformLoadsBlock.Loads[2].MagnitudeStartPLF);
            Assert.AreEqual(1.84, T385.LoadCases[29].UniformLoadsBlock.Loads[3].EndXFeet);
            Assert.AreEqual(36.41, T385.LoadCases[29].UniformLoadsBlock.Loads[4].EndYFeet);
            Assert.AreEqual(-84.2, T385.LoadCases[29].UniformLoadsBlock.Loads[5].MagnitudeEndPLF);
            Assert.AreEqual(false, T385.LoadCases[29].UniformLoadsBlock.Loads[6].LiveLoad);
        }
        [Test]
        public void T20Case30ReactionDataTest()
        {
            Assert.AreEqual(0, T20.LoadCases[30].ReactionDataBlock.Bearings[0].BearingNumber);
            Assert.AreEqual(119.435, T20.LoadCases[30].ReactionDataBlock.Bearings[1].VerticalReactionPounds);
            Assert.AreEqual(26709.60, T20.LoadCases[30].ReactionDataBlock.Bearings[2].VerticalAllowablePounds);
            Assert.AreEqual(0, T20.LoadCases[30].ReactionDataBlock.Bearings[3].HorizontalPounds);
            Assert.AreEqual(0, T20.LoadCases[30].ReactionDataBlock.Bearings[4].MomentFtPound);
            Assert.AreEqual(1234567890, T20.LoadCases[30].ReactionDataBlock.Bearings[3].XLocation);
            Assert.AreEqual(1234567890, T20.LoadCases[30].ReactionDataBlock.Bearings[2].YLocation);
        }
        [Test]
        public void T1Case31CSIDataTest()
        {
            Assert.AreEqual(0, T1.LoadCases[31].CSIDataBlock.Members[0].AX);
            Assert.AreEqual(.207, T1.LoadCases[31].CSIDataBlock.Members[1].BD);
            Assert.AreEqual(.199, T1.LoadCases[31].CSIDataBlock.Members[2].Total);
            Assert.AreEqual(15.19, T1.LoadCases[31].CSIDataBlock.Members[3].LocMaxFeet);
            Assert.AreEqual(76.88, T1.LoadCases[31].CSIDataBlock.Members[4].LenInches);
            Assert.AreEqual(.6814, T1.LoadCases[31].CSIDataBlock.Members[5].Ke);
            Assert.AreEqual(1, T1.LoadCases[31].CSIDataBlock.Members[6].RAF);
            Assert.AreEqual(1.15, T1.LoadCases[31].CSIDataBlock.Members[7].RBF);
        }
        [Test]
        public void T385Case29CSIShearDataTest()
        {
            Assert.AreEqual(7.41, T385.LoadCases[29].CSIShearDataBlock.Members[0].Actual);
            Assert.AreEqual(280, T385.LoadCases[29].CSIShearDataBlock.Members[1].Allowable);
            Assert.AreEqual(0.090, T385.LoadCases[29].CSIShearDataBlock.Members[2].Csi);
            Assert.AreEqual(20.375, T385.LoadCases[29].CSIShearDataBlock.Members[3].Location);
        }
        [Test]
        public void T20Case33ForceDataTest()
        {
            Assert.AreEqual(106.16, T20.LoadCases[33].ForceDataBlock.Members[0].NegativeEndAxialPounds);
            Assert.AreEqual(-121.64, T20.LoadCases[33].ForceDataBlock.Members[1].NegativeEndShearPounds);
            Assert.AreEqual(-6.60, T20.LoadCases[33].ForceDataBlock.Members[2].NegativeMomentPounds);
            Assert.AreEqual(156.64, T20.LoadCases[33].ForceDataBlock.Members[3].PositiveEndAxialPounds);
            Assert.AreEqual(-15.35, T20.LoadCases[33].ForceDataBlock.Members[4].PositiveEndShearPounds);
            Assert.AreEqual(362.83, T20.LoadCases[33].ForceDataBlock.Members[5].PositiveMomentPounds);
        }
    }
}
