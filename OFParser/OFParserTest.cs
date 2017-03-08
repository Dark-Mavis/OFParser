using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    using NUnit.Framework;
namespace OFParser
{
    [TestFixture]
    class OFParserTest
    {
        OFParser T20 = new OFParser("C: /Users/Cerullium/OneDrive/Work/OFParser/OF Parser/OF_File_Examples/T20.OF");
        OFParser T1 = new OFParser("C: /Users/Cerullium/OneDrive/Work/OFParser/OF Parser/OF_File_Examples/T1.OF");
        OFParser T385 = new OFParser("C: /Users/Cerullium/OneDrive/Work/OFParser/OF Parser/OF_File_Examples/T385.OF");
        [Test]
        public void T20BaseNMiscDataTest()
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
        public void T1BaseNMiscDataTest()
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
        public void T20MiscNJointDataTest()
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
        public void T1MiscNJointDataTest()
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
        public void T385PlateInfoNDataTest()
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
            Assert.AreEqual("WAVE", T20.QualityControlToothCountsBlock.Joints[3].PlateType);
            Assert.AreEqual(4, T20.QualityControlToothCountsBlock.Joints[6].Teeths[0].MemberNumber);
            Assert.AreEqual(13, T20.QualityControlToothCountsBlock.Joints[8].Teeths[0].RequiredTeeth);
            Assert.AreEqual(59, T20.QualityControlToothCountsBlock.Joints[10].Teeths[0].AvailableTeeth);
            Assert.AreEqual(8, T20.QualityControlToothCountsBlock.Joints[13].Teeths[1].MemberNumber);
            Assert.AreEqual(10, T20.QualityControlToothCountsBlock.Joints[17].Teeths[1].RequiredTeeth);
            Assert.AreEqual(25, T20.QualityControlToothCountsBlock.Joints[13].Teeths[1].AvailableTeeth);
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
            Assert.AreEqual("WAVE", T385.QualityControlToothCountsBlock.Joints[2].PlateType);
            Assert.AreEqual(4, T385.QualityControlToothCountsBlock.Joints[5].Teeths[0].MemberNumber);
            Assert.AreEqual(12, T385.QualityControlToothCountsBlock.Joints[6].Teeths[0].RequiredTeeth);
            Assert.AreEqual(32, T385.QualityControlToothCountsBlock.Joints[10].Teeths[0].AvailableTeeth);
            Assert.AreEqual(3, T385.QualityControlToothCountsBlock.Joints[12].Teeths[1].MemberNumber);
            Assert.AreEqual(3, T385.QualityControlToothCountsBlock.Joints[10].Teeths[1].RequiredTeeth);
            Assert.AreEqual(38, T385.QualityControlToothCountsBlock.Joints[6].Teeths[1].AvailableTeeth);
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
            Assert.AreEqual(-1, T20.MemberDataBlock.Members[7].PurlinSpacing);
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
            Assert.AreEqual(0, T1.MemberDataBlock.Members[7].PurlinSpacing);
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
            Assert.AreEqual(0, T385.MemberDataBlock.Members[7].PurlinSpacing);
        }
        [Test]
        public void T20LumberDataTest()
        {
            Assert.AreEqual(7, T20.LumberDataBlock.Lumbers[6].Grade);
            Assert.AreEqual(3.50, T20.LumberDataBlock.Lumbers[7].Depth);
            Assert.AreEqual(1.50, T20.LumberDataBlock.Lumbers[17].Thick);
            Assert.AreEqual("STACKED CHORD FICT MEMBER", T20.LumberDataBlock.Lumbers[18].Description);
            Assert.AreEqual(1000000, T20.LumberDataBlock.Lumbers[17].E);
            Assert.AreEqual(1100, T20.LumberDataBlock.Lumbers[7].Fb);
            Assert.AreEqual(850, T20.LumberDataBlock.Lumbers[6].Fc);
            Assert.AreEqual(675, T20.LumberDataBlock.Lumbers[7].Ft);
            Assert.AreEqual(0, T20.LumberDataBlock.Lumbers[17].Fcp);
            Assert.AreEqual(0, T20.LumberDataBlock.Lumbers[18].Fv);
            Assert.AreEqual(MSR.F, T20.LumberDataBlock.Lumbers[17].MSR);
            Assert.AreEqual(CW.CW, T20.LumberDataBlock.Lumbers[7].CW);
            Assert.AreEqual("2x4", T20.LumberDataBlock.Lumbers[6].SizeName);
        }
        [Test]
        public void T1LumberDataTest()
        {
            Assert.AreEqual(7, T1.LumberDataBlock.Lumbers[6].Grade);
            Assert.AreEqual(3.50, T1.LumberDataBlock.Lumbers[8].Depth);
            Assert.AreEqual(1.50, T1.LumberDataBlock.Lumbers[17].Thick);
            Assert.AreEqual("STACKED CHORD FICT MEMBER", T1.LumberDataBlock.Lumbers[18].Description);
            Assert.AreEqual(1000000, T1.LumberDataBlock.Lumbers[17].E);
            Assert.AreEqual(1500, T1.LumberDataBlock.Lumbers[8].Fb);
            Assert.AreEqual(850, T1.LumberDataBlock.Lumbers[6].Fc);
            Assert.AreEqual(1000, T1.LumberDataBlock.Lumbers[8].Ft);
            Assert.AreEqual(0, T1.LumberDataBlock.Lumbers[17].Fcp);
            Assert.AreEqual(0, T1.LumberDataBlock.Lumbers[18].Fv);
            Assert.AreEqual(MSR.F, T1.LumberDataBlock.Lumbers[17].MSR);
            Assert.AreEqual(CW.CW, T1.LumberDataBlock.Lumbers[8].CW);
            Assert.AreEqual("2x4", T1.LumberDataBlock.Lumbers[6].SizeName);
        }
        [Test]
        public void T385LumberDataTest()
        {
            Assert.AreEqual(7, T385.LumberDataBlock.Lumbers[6].Grade);
            Assert.AreEqual(3.50, T385.LumberDataBlock.Lumbers[7].Depth);
            Assert.AreEqual(1.50, T385.LumberDataBlock.Lumbers[17].Thick);
            Assert.AreEqual("STACKED CHORD FICT MEMBER", T385.LumberDataBlock.Lumbers[18].Description);
            Assert.AreEqual(1000000, T385.LumberDataBlock.Lumbers[17].E);
            Assert.AreEqual(1100, T385.LumberDataBlock.Lumbers[7].Fb);
            Assert.AreEqual(850, T385.LumberDataBlock.Lumbers[6].Fc);
            Assert.AreEqual(675, T385.LumberDataBlock.Lumbers[7].Ft);
            Assert.AreEqual(0, T385.LumberDataBlock.Lumbers[17].Fcp);
            Assert.AreEqual(0, T385.LumberDataBlock.Lumbers[18].Fv);
            Assert.AreEqual(MSR.F, T385.LumberDataBlock.Lumbers[17].MSR);
            Assert.AreEqual(CW.CW, T385.LumberDataBlock.Lumbers[7].CW);
            Assert.AreEqual("2x4", T385.LumberDataBlock.Lumbers[6].SizeName);
        }
        [Test]
        public void T20BearingDataTest()
        {
            Assert.AreEqual(Type.Pin, T20.BearingDataBlock.Bearings[1].Joints[0]);
            Assert.AreEqual(1.594, T20.BearingDataBlock.Bearings[2].Width);
            Assert.AreEqual(0, T20.BearingDataBlock.Bearings[1].XCoord);
            Assert.AreEqual(39.651, T20.BearingDataBlock.Bearings[2].YCoord);
            Assert.AreEqual(2, T20.BearingDataBlock.Bearings[1].BearingType);
            Assert.AreEqual("Rigid Surface", T20.BearingDataBlock.Bearings[2].WallSpecies);
            Assert.AreEqual(99.000, T20.BearingDataBlock.MaxProtrusionOfSupportingFastener);
            Assert.AreEqual(false, T20.BearingDataBlock.OnlyFastenersGreaterThanOnePointFiveInchesInMultiPlySupportingMember);
        }
        [Test]
        public void T1BearingDataTest()
        {
            Assert.AreEqual(Type.Pin, T1.BearingDataBlock.Bearings[1].Joints[1]);
            Assert.AreEqual(1.500, T1.BearingDataBlock.Bearings[2].Width);
            Assert.AreEqual(0, T1.BearingDataBlock.Bearings[1].XCoord);
            Assert.AreEqual(29.792, T1.BearingDataBlock.Bearings[2].YCoord);
            Assert.AreEqual(2, T1.BearingDataBlock.Bearings[1].BearingType);
            Assert.AreEqual("Rigid Surface", T1.BearingDataBlock.Bearings[2].WallSpecies);
            Assert.AreEqual(99.000, T1.BearingDataBlock.MaxProtrusionOfSupportingFastener);
            Assert.AreEqual(false, T1.BearingDataBlock.OnlyFastenersGreaterThanOnePointFiveInchesInMultiPlySupportingMember);
        }
        [Test]
        public void T385BearingDataTest()
        {
            Assert.AreEqual(Type.Roll, T385.BearingDataBlock.Bearings[1].Joints[2]);
            Assert.AreEqual(1.500, T385.BearingDataBlock.Bearings[1].Width);
            Assert.AreEqual(0, T385.BearingDataBlock.Bearings[1].XCoord);
            Assert.AreEqual(32.163, T385.BearingDataBlock.Bearings[1].YCoord);
            Assert.AreEqual(2, T385.BearingDataBlock.Bearings[1].BearingType);
            Assert.AreEqual("Rigid Surface", T385.BearingDataBlock.Bearings[1].WallSpecies);
            Assert.AreEqual(99.000, T385.BearingDataBlock.MaxProtrusionOfSupportingFastener);
            Assert.AreEqual(false, T385.BearingDataBlock.OnlyFastenersGreaterThanOnePointFiveInchesInMultiPlySupportingMember);
        }

        [Test]
        public void T20Case1LoadingDataTest()
        {
            Assert.AreEqual("STD.AUTO.LOAD", T20.LoadCases[1].LoadCaseType);
            Assert.AreEqual(2.00, T20.LoadCases[1].Spacing);
            Assert.AreEqual(1.25, T20.LoadCases[1].DurationFactor);
            Assert.AreEqual(1.25, T20.LoadCases[1].PlateDurationFactor);
            Assert.AreEqual(1, T20.LoadCases[1].NumberOfPlys);
            Assert.AreEqual(false, T20.LoadCases[1].UserModifiedLoads);
            Assert.AreEqual(1, T20.LoadCases[1].KindOfLoadCase);
            Assert.AreEqual(true, T20.LoadCases[1].RepetitiveFactorsUsed);
            Assert.AreEqual(2.00, T20.LoadCases[1].SoffitDeadLoad);
        }
        [Test]
        public void T1Case2UniformLoadsTest()
        {
            Assert.AreEqual(0, T1.LoadCases[2].UniformLoadsBlock.Loads[0].StartX);
            Assert.AreEqual(38.55, T1.LoadCases[2].UniformLoadsBlock.Loads[1].StartY);
            Assert.AreEqual(4.0, T1.LoadCases[2].UniformLoadsBlock.Loads[2].MagnitudeStart);
            Assert.AreEqual(15.19, T1.LoadCases[2].UniformLoadsBlock.Loads[3].EndX);
            Assert.AreEqual(24.79, T1.LoadCases[2].UniformLoadsBlock.Loads[2].EndY);
            Assert.AreEqual(7.7, T1.LoadCases[2].UniformLoadsBlock.Loads[1].MagnitudeEnd);
            Assert.AreEqual(0, T1.LoadCases[2].UniformLoadsBlock.Loads[0].LiveLoad);
        }
        [Test]
        public void T385Case3ReactionDataTest()
        {
            Assert.AreEqual(0, T385.LoadCases[3].ReactionDataBlock.Bearings[0].BearingNumber);
            Assert.AreEqual(242.105, T385.LoadCases[3].ReactionDataBlock.Bearings[1].VerticalReactionNumber);
            Assert.AreEqual(32575.76, T385.LoadCases[3].ReactionDataBlock.Bearings[2].VerticalAllowableNumber);
            Assert.AreEqual(-0.00, T385.LoadCases[3].ReactionDataBlock.Bearings[1].HorizontalNumber);
            Assert.AreEqual(0.00, T385.LoadCases[3].ReactionDataBlock.Bearings[0].MomentNumber);
            Assert.AreEqual(1234567890, T385.LoadCases[3].ReactionDataBlock.Bearings[1].XLocation);
            Assert.AreEqual(1234567890, T385.LoadCases[3].ReactionDataBlock.Bearings[2].YLocation);
        }
        [Test]
        public void T20Case4CSIDataTest()
        {
            Assert.AreEqual(0.015, T20.LoadCases[4].CSIDataBlock.Members[0].AX);
            Assert.AreEqual(0.147, T20.LoadCases[4].CSIDataBlock.Members[1].BD);
            Assert.AreEqual(0.062, T20.LoadCases[4].CSIDataBlock.Members[2].Total);
            Assert.AreEqual(10.85, T20.LoadCases[4].CSIDataBlock.Members[3].LocMax);
            Assert.AreEqual(56.41, T20.LoadCases[4].CSIDataBlock.Members[4].Len);
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
            Assert.AreEqual(0.15, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[1].XLocation);
            Assert.AreEqual(-0.00, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[2].LiveLoadX);
            Assert.AreEqual(-0.00, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[3].LiveLoadY);
            Assert.AreEqual(0.27, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[4].Allow);
            Assert.AreEqual(-0.00, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[5].DeadLoadX);
            Assert.AreEqual(0.00, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[6].DeadLoadY);
            Assert.AreEqual(0.00, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[7].TotalLoadsX);
            Assert.AreEqual(0.00, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[6].TotalLoadsY);
            Assert.AreEqual(0.40, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[5].AllowTotal);
            Assert.AreEqual(7.96, T385.LoadCases[6].DeflectionPPDataBlock.Deflects[4].Span);
        }
        [Test]
        public void T20Case7DeflectionMPDataTest()
        {
            Assert.AreEqual("TC", T20.LoadCases[7].DeflectionMPDataBlock.Deflects[0].Label);
            Assert.AreEqual(3.74, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[1].XLocation);
            Assert.AreEqual(0.00, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[2].LiveLoadX);
            Assert.AreEqual(0.03, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[3].LiveLoadY);
            Assert.AreEqual(0.24, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[4].Allow);
            Assert.AreEqual(0.00, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[5].DeadLoadX);
            Assert.AreEqual(0.04, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[6].DeadLoadY);
            Assert.AreEqual(0.00, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[7].TotalLoadsX);
            Assert.AreEqual(-0.00, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[8].TotalLoadsY);
            Assert.AreEqual(0.03, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[9].AllowTotal);
            Assert.AreEqual(0.29, T20.LoadCases[7].DeflectionMPDataBlock.Deflects[10].Span);
        }
        [Test]
        public void T1Case8ForceDataTest()
        {
            Assert.AreEqual(341.97, T1.LoadCases[8].ForceDataBlock.Members[0].NegativeEndAxialNumber);
            Assert.AreEqual(208.03, T1.LoadCases[8].ForceDataBlock.Members[1].NegativeEndShearNumber);
            Assert.AreEqual(1304.22, T1.LoadCases[8].ForceDataBlock.Members[2].NegativeEndMoment);
            Assert.AreEqual(0.00, T1.LoadCases[8].ForceDataBlock.Members[3].PositiveEndAxialNumber);
            Assert.AreEqual(76.77, T1.LoadCases[8].ForceDataBlock.Members[4].PositiveEndShearNumber);
            Assert.AreEqual(-564.56, T1.LoadCases[8].ForceDataBlock.Members[5].PositiveEndMoment);
        }

        [Test]
        public void T385Case10LoadingDataTest()
        {
            Assert.AreEqual("MWFRS ASCE Perp/R+-", T385.LoadCases[10].LoadCaseType);
            Assert.AreEqual(2.00, T385.LoadCases[10].Spacing);
            Assert.AreEqual(1.60, T385.LoadCases[10].DurationFactor);
            Assert.AreEqual(1.60, T385.LoadCases[10].PlateDurationFactor);
            Assert.AreEqual(1, T385.LoadCases[10].NumberOfPlys);
            Assert.AreEqual(false, T385.LoadCases[10].UserModifiedLoads);
            Assert.AreEqual(6, T385.LoadCases[10].KindOfLoadCase);
            Assert.AreEqual(true, T385.LoadCases[10].RepetitiveFactorsUsed);
            Assert.AreEqual(2.00, T385.LoadCases[10].SoffitDeadLoad);
        }
        [Test]
        public void T20Case11UniformLoadsTest()
        {
            Assert.AreEqual(0, T20.LoadCases[11].UniformLoadsBlock.Loads[0].StartX);
            Assert.AreEqual(46.52, T20.LoadCases[11].UniformLoadsBlock.Loads[1].StartY);
            Assert.AreEqual(24.0, T20.LoadCases[11].UniformLoadsBlock.Loads[2].MagnitudeStart);
            Assert.AreEqual(8.59, T20.LoadCases[11].UniformLoadsBlock.Loads[3].EndX);
            Assert.AreEqual(46.52, T20.LoadCases[11].UniformLoadsBlock.Loads[4].EndY);
            Assert.AreEqual(20, T20.LoadCases[11].UniformLoadsBlock.Loads[5].MagnitudeEnd);
            Assert.AreEqual(1, T20.LoadCases[11].UniformLoadsBlock.Loads[4].LiveLoad);
        }
        [Test]
        public void T1Case12ReactionDataTest()
        {
            Assert.AreEqual(1, T1.LoadCases[12].ReactionDataBlock.Bearings[0].BearingNumber);
            Assert.AreEqual(-245.441, T1.LoadCases[12].ReactionDataBlock.Bearings[1].VerticalReactionNumber);
            Assert.AreEqual(999999, T1.LoadCases[12].ReactionDataBlock.Bearings[0].VerticalAllowableNumber);
            Assert.AreEqual(0, T1.LoadCases[12].ReactionDataBlock.Bearings[1].HorizontalNumber);
            Assert.AreEqual(0, T1.LoadCases[12].ReactionDataBlock.Bearings[0].MomentNumber);
            Assert.AreEqual(12.44, T1.LoadCases[12].ReactionDataBlock.Bearings[1].XLocation);
            Assert.AreEqual(29.79, T1.LoadCases[12].ReactionDataBlock.Bearings[0].YLocation);
        }
        [Test]
        public void T385Case13CSIDataTest()
        {
            Assert.AreEqual(0, T385.LoadCases[13].CSIDataBlock.Members[0].AX);
            Assert.AreEqual(0.023, T385.LoadCases[13].CSIDataBlock.Members[1].BD);
            Assert.AreEqual(0.020, T385.LoadCases[13].CSIDataBlock.Members[2].Total);
            Assert.AreEqual(1.7, T385.LoadCases[13].CSIDataBlock.Members[3].LocMax);
            Assert.AreEqual(7.29, T385.LoadCases[13].CSIDataBlock.Members[4].Len);
            Assert.AreEqual(.731, T385.LoadCases[13].CSIDataBlock.Members[5].Ke);
            Assert.AreEqual(1.1, T385.LoadCases[13].CSIDataBlock.Members[7].RAF);
            Assert.AreEqual(1.15, T385.LoadCases[13].CSIDataBlock.Members[10].RBF);
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
            Assert.AreEqual(0, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[1].XLocation);
            Assert.AreEqual(0, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[2].LiveLoadX);
            Assert.AreEqual(-0.01, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[3].LiveLoadY);
            Assert.AreEqual(.42, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[4].Allow);
            Assert.AreEqual(0, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[5].DeadLoadX);
            Assert.AreEqual(-0.02, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[6].DeadLoadY);
            Assert.AreEqual(0, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[7].TotalLoadsX);
            Assert.AreEqual(-0.02, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[8].TotalLoadsY);
            Assert.AreEqual(.25, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[9].AllowTotal);
            Assert.AreEqual(.29, T1.LoadCases[15].DeflectionPPDataBlock.Deflects[8].Span);
        }
        [Test]
        public void T385Case16DeflectionMPDataTest()
        {
            Assert.AreEqual("TC", T385.LoadCases[16].DeflectionMPDataBlock.Deflects[0].Label);
            Assert.AreEqual(4.97, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[1].XLocation);
            Assert.AreEqual(0.00, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[2].LiveLoadX);
            Assert.AreEqual(0.02, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[3].LiveLoadY);
            Assert.AreEqual(0.05, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[4].Allow);
            Assert.AreEqual(0.00, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[5].DeadLoadX);
            Assert.AreEqual(0.00, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[4].DeadLoadY);
            Assert.AreEqual(0.00, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[3].TotalLoadsX);
            Assert.AreEqual(0.00, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[2].TotalLoadsY);
            Assert.AreEqual(0.63, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[1].AllowTotal);
            Assert.AreEqual(1.16, T385.LoadCases[16].DeflectionMPDataBlock.Deflects[0].Span);
        }
        [Test]
        public void T20Case17ForceDataTest()
        {
            Assert.AreEqual(159.78, T20.LoadCases[17].ForceDataBlock.Members[0].NegativeEndAxialNumber);
            Assert.AreEqual(-47.01, T20.LoadCases[17].ForceDataBlock.Members[1].NegativeEndShearNumber);
            Assert.AreEqual(-2.10, T20.LoadCases[17].ForceDataBlock.Members[2].NegativeEndMoment);
            Assert.AreEqual(-19.21, T20.LoadCases[17].ForceDataBlock.Members[3].PositiveEndAxialNumber);
            Assert.AreEqual(-13.16, T20.LoadCases[17].ForceDataBlock.Members[4].PositiveEndShearNumber);
            Assert.AreEqual(-60.94, T20.LoadCases[17].ForceDataBlock.Members[5].PositiveEndMoment);
        }

        [Test]
        public void T1Case18LoadingDataTest()
        {
            Assert.AreEqual("MWFRS ASCE Parl+-", T1.LoadCases[18].LoadCaseType);
            Assert.AreEqual(2.00, T1.LoadCases[18].Spacing);
            Assert.AreEqual(1.60, T1.LoadCases[18].DurationFactor);
            Assert.AreEqual(1.60, T1.LoadCases[18].PlateDurationFactor);
            Assert.AreEqual(1, T1.LoadCases[18].NumberOfPlys);
            Assert.AreEqual(false, T1.LoadCases[18].UserModifiedLoads);
            Assert.AreEqual(6, T1.LoadCases[18].KindOfLoadCase);
            Assert.AreEqual(true, T1.LoadCases[18].RepetitiveFactorsUsed);
            Assert.AreEqual(2.00, T1.LoadCases[18].SoffitDeadLoad);
        }
        [Test]
        public void T385Case19ExtraInfoTest()
        {
            Assert.AreEqual("ASCE 7-10 Wind Type Load Case", T385.LoadCases[19].ExtraInfoBlock.LoadCaseName);
            Assert.AreEqual("B", T385.LoadCases[19].ExtraInfoBlock.ExposureType);
            Assert.AreEqual("Residence", T385.LoadCases[19].ExtraInfoBlock.BuildingClass);
            Assert.AreEqual(142, T385.LoadCases[19].ExtraInfoBlock.WindSpeed);
            Assert.AreEqual("Closed", T385.LoadCases[19].ExtraInfoBlock.BuildingType);
            Assert.AreEqual(4.2, T385.LoadCases[19].ExtraInfoBlock.DLTop);
            Assert.AreEqual(1.8, T385.LoadCases[19].ExtraInfoBlock.DLBottom);
            Assert.AreEqual(32.93, T385.LoadCases[19].ExtraInfoBlock.Height);
            Assert.AreEqual(true, T385.LoadCases[19].ExtraInfoBlock.Ceiling);
            Assert.AreEqual(true, T385.LoadCases[19].ExtraInfoBlock.Zone1);
            Assert.AreEqual(false, T385.LoadCases[19].ExtraInfoBlock.Zone2);
            Assert.AreEqual(275, T385.LoadCases[19].ExtraInfoBlock.Uplifts1);
            Assert.AreEqual(1234567890, T385.LoadCases[19].ExtraInfoBlock.Uplifts2);
        }
        [Test]
        public void T20Case20UniformLoadsTest()
        {
            Assert.AreEqual(0.77, T20.LoadCases[20].UniformLoadsBlock.Loads[0].StartX);
            Assert.AreEqual(39.53, T20.LoadCases[20].UniformLoadsBlock.Loads[1].StartY);
            Assert.AreEqual(10.1, T20.LoadCases[20].UniformLoadsBlock.Loads[2].MagnitudeStart);
            Assert.AreEqual(0.77, T20.LoadCases[20].UniformLoadsBlock.Loads[3].EndX);
            Assert.AreEqual(46.52, T20.LoadCases[20].UniformLoadsBlock.Loads[4].EndY);
            Assert.AreEqual(10.1, T20.LoadCases[20].UniformLoadsBlock.Loads[5].MagnitudeEnd);
            Assert.AreEqual(1.00, T20.LoadCases[20].UniformLoadsBlock.Loads[6].LiveLoad);
        }
        [Test]
        public void T1Case21ReactionDataTest()
        {
            Assert.AreEqual(1, T1.LoadCases[21].ReactionDataBlock.Bearings[0].BearingNumber);
            Assert.AreEqual(368.036, T1.LoadCases[21].ReactionDataBlock.Bearings[1].VerticalReactionNumber);
            Assert.AreEqual(4661.23, T1.LoadCases[21].ReactionDataBlock.Bearings[0].VerticalAllowableNumber);
            Assert.AreEqual(0, T1.LoadCases[21].ReactionDataBlock.Bearings[1].HorizontalNumber);
            Assert.AreEqual(0, T1.LoadCases[21].ReactionDataBlock.Bearings[0].MomentNumber);
            Assert.AreEqual(12.44, T1.LoadCases[21].ReactionDataBlock.Bearings[1].XLocation);
            Assert.AreEqual(29.79, T1.LoadCases[21].ReactionDataBlock.Bearings[0].YLocation);
        }
        [Test]
        public void T385Case22CSIDataTest()
        {
            Assert.AreEqual(0, T385.LoadCases[22].CSIDataBlock.Members[0].AX);
            Assert.AreEqual(0.125, T385.LoadCases[22].CSIDataBlock.Members[1].BD);
            Assert.AreEqual(0.166, T385.LoadCases[22].CSIDataBlock.Members[2].Total);
            Assert.AreEqual(1.7, T385.LoadCases[22].CSIDataBlock.Members[3].LocMax);
            Assert.AreEqual(7.29, T385.LoadCases[22].CSIDataBlock.Members[4].Len);
            Assert.AreEqual(.731, T385.LoadCases[22].CSIDataBlock.Members[5].Ke);
            Assert.AreEqual(1.1, T385.LoadCases[22].CSIDataBlock.Members[7].RAF);
            Assert.AreEqual(1.15, T385.LoadCases[22].CSIDataBlock.Members[10].RBF);
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
            Assert.AreEqual(0, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[1].XLocation);
            Assert.AreEqual(0, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[2].LiveLoadX);
            Assert.AreEqual(0, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[3].LiveLoadY);
            Assert.AreEqual(.42, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[4].Allow);
            Assert.AreEqual(0, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[5].DeadLoadX);
            Assert.AreEqual(0.09, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[6].DeadLoadY);
            Assert.AreEqual(0, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[7].TotalLoadsX);
            Assert.AreEqual(0.02, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[8].TotalLoadsY);
            Assert.AreEqual(.25, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[9].AllowTotal);
            Assert.AreEqual(.29, T1.LoadCases[24].DeflectionPPDataBlock.Deflects[8].Span);
        }
        [Test]
        public void T385Case25ForceDataTest()
        {
            Assert.AreEqual(-27.78, T385.LoadCases[25].ForceDataBlock.Members[0].NegativeEndAxialNumber);
            Assert.AreEqual(-168.14, T385.LoadCases[25].ForceDataBlock.Members[1].NegativeEndShearNumber);
            Assert.AreEqual(54.42, T385.LoadCases[25].ForceDataBlock.Members[2].NegativeEndMoment);
            Assert.AreEqual(-34.03, T385.LoadCases[25].ForceDataBlock.Members[3].PositiveEndAxialNumber);
            Assert.AreEqual(0.00, T385.LoadCases[25].ForceDataBlock.Members[4].PositiveEndShearNumber);
            Assert.AreEqual(-12.60, T385.LoadCases[25].ForceDataBlock.Members[5].PositiveEndMoment);
        }

        [Test]
        public void T20Case27LoadingDataTest()
        {
            Assert.AreEqual("MWFRS ASCE PrpD/L--", T20.LoadCases[27].LoadCaseType);
            Assert.AreEqual(2.00, T20.LoadCases[27].Spacing);
            Assert.AreEqual(1.60, T20.LoadCases[27].DurationFactor);
            Assert.AreEqual(1.60, T20.LoadCases[27].PlateDurationFactor);
            Assert.AreEqual(1, T20.LoadCases[27].NumberOfPlys);
            Assert.AreEqual(false, T20.LoadCases[27].UserModifiedLoads);
            Assert.AreEqual(6, T20.LoadCases[27].KindOfLoadCase);
            Assert.AreEqual(true, T20.LoadCases[27].RepetitiveFactorsUsed);
            Assert.AreEqual(2.00, T20.LoadCases[27].SoffitDeadLoad);
        }
        [Test]
        public void T1Case28ExtraInfoTest()
        {
            Assert.AreEqual("ASCE 7-10 Wind Type Load Case", T1.LoadCases[28].ExtraInfoBlock.LoadCaseName);
            Assert.AreEqual("B", T1.LoadCases[28].ExtraInfoBlock.ExposureType);
            Assert.AreEqual("Residence", T1.LoadCases[28].ExtraInfoBlock.BuildingClass);
            Assert.AreEqual(142, T1.LoadCases[28].ExtraInfoBlock.WindSpeed);
            Assert.AreEqual("Closed", T1.LoadCases[28].ExtraInfoBlock.BuildingType);
            Assert.AreEqual(4.2, T1.LoadCases[28].ExtraInfoBlock.DLTop);
            Assert.AreEqual(1.8, T1.LoadCases[28].ExtraInfoBlock.DLBottom);
            Assert.AreEqual(35.55, T1.LoadCases[28].ExtraInfoBlock.Height);
            Assert.AreEqual(true, T1.LoadCases[28].ExtraInfoBlock.Ceiling);
            Assert.AreEqual(true, T1.LoadCases[28].ExtraInfoBlock.Zone1);
            Assert.AreEqual(false, T1.LoadCases[28].ExtraInfoBlock.Zone2);
            Assert.AreEqual(230, T1.LoadCases[28].ExtraInfoBlock.Uplifts1);
            Assert.AreEqual(423, T1.LoadCases[28].ExtraInfoBlock.Uplifts2);
        }
        [Test]
        public void T385Case29UniformLoadsTest()
        {
            Assert.AreEqual(1.84, T385.LoadCases[29].UniformLoadsBlock.Loads[0].StartX);
            Assert.AreEqual(32.20, T385.LoadCases[29].UniformLoadsBlock.Loads[1].StartY);
            Assert.AreEqual(24, T385.LoadCases[29].UniformLoadsBlock.Loads[2].MagnitudeStart);
            Assert.AreEqual(1.84, T385.LoadCases[29].UniformLoadsBlock.Loads[3].EndX);
            Assert.AreEqual(36.41, T385.LoadCases[29].UniformLoadsBlock.Loads[4].EndY);
            Assert.AreEqual(-84.2, T385.LoadCases[29].UniformLoadsBlock.Loads[5].MagnitudeEnd);
            Assert.AreEqual(0, T385.LoadCases[29].UniformLoadsBlock.Loads[6].LiveLoad);
        }
        [Test]
        public void T20Case30ReactionDataTest()
        {
            Assert.AreEqual(0, T20.LoadCases[30].ReactionDataBlock.Bearings[0].BearingNumber);
            Assert.AreEqual(119.435, T20.LoadCases[30].ReactionDataBlock.Bearings[1].VerticalReactionNumber);
            Assert.AreEqual(26709.60, T20.LoadCases[30].ReactionDataBlock.Bearings[2].VerticalAllowableNumber);
            Assert.AreEqual(0, T20.LoadCases[30].ReactionDataBlock.Bearings[3].HorizontalNumber);
            Assert.AreEqual(0, T20.LoadCases[30].ReactionDataBlock.Bearings[4].MomentNumber);
            Assert.AreEqual(1234567890, T20.LoadCases[30].ReactionDataBlock.Bearings[3].XLocation);
            Assert.AreEqual(1234567890, T20.LoadCases[30].ReactionDataBlock.Bearings[2].YLocation);
        }
        [Test]
        public void T1Case31CSIDataTest()
        {
            Assert.AreEqual(0, T1.LoadCases[31].CSIDataBlock.Members[0].AX);
            Assert.AreEqual(.207, T1.LoadCases[31].CSIDataBlock.Members[1].BD);
            Assert.AreEqual(.199, T1.LoadCases[31].CSIDataBlock.Members[2].Total);
            Assert.AreEqual(15.19, T1.LoadCases[31].CSIDataBlock.Members[3].LocMax);
            Assert.AreEqual(76.88, T1.LoadCases[31].CSIDataBlock.Members[4].Len);
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
            Assert.AreEqual(106.16, T20.LoadCases[33].ForceDataBlock.Members[0].NegativeEndAxialNumber);
            Assert.AreEqual(-121.64, T20.LoadCases[33].ForceDataBlock.Members[1].NegativeEndShearNumber);
            Assert.AreEqual(-6.60, T20.LoadCases[33].ForceDataBlock.Members[2].NegativeEndMoment);
            Assert.AreEqual(156.64, T20.LoadCases[33].ForceDataBlock.Members[3].PositiveEndAxialNumber);
            Assert.AreEqual(-15.35, T20.LoadCases[33].ForceDataBlock.Members[4].PositiveEndShearNumber);
            Assert.AreEqual(362.83, T20.LoadCases[33].ForceDataBlock.Members[5].PositiveEndMoment);
        }
    }
}
