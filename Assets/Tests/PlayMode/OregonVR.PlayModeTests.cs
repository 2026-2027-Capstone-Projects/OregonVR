
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestCI
{
    [UnityTest]
    public IEnumerator BasicPlayModeTest()
    {
        GameObject testObject = new GameObject("TestObject");

        Assert.IsNotNull(testObject);

        yield return null;

        Object.DestroyImmediate(testObject);
    }

    [Test]
    public void ModelClickListener_LogsMessage()
    {
        GameObject testObject = new GameObject("TestModel");

        try
        {
            ModelClickListener listener =
                testObject.AddComponent<ModelClickListener>();

            LogAssert.Expect(LogType.Log, "User click");

            listener.HandleClick();

            LogAssert.NoUnexpectedReceived();
        }
        finally
        {
            Object.DestroyImmediate(testObject);
        }
    }
}
