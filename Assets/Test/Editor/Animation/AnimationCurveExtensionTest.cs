using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using NUnit.Framework;


[TestFixture]
public class AnimationCurveExtensionTest {

    [Test]
    public void LastTimeNoKey()
    {
        var curve = new AnimationCurve();
        Assert.Throws<InvalidOperationException>(() => curve.LastTime());
    }

    [TestCase(0f)]
    [TestCase(float.MinValue)]
    [TestCase(float.MaxValue)]
    public void LastTimeSingleKey(float time)
    {
        var curve = new AnimationCurve(new Keyframe(time, 0f));
        Assert.AreEqual(curve.LastTime(), time);
    }

    [TestCase(2)]
    [TestCase(100)]
    public void LastTimeMultiKey(int num)
    {
        var ary = Enumerable.Range(0, num+1).Select(i =>  new Keyframe(i, i)).ToArray();
        var curve = new AnimationCurve(ary);
        Assert.AreEqual(curve.LastTime(), num);
    }
}
