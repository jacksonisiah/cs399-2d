using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class NewTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        var scene = "Level1";
        var timeoutCounter = 0;
        var timeoutCounterThreshold = 0;

        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        yield return null;

        var testScene = SceneManager.GetSceneByName(scene);

        if (testScene.IsValid() && testScene.IsValid())
        {
            while (!SceneManager.SetActiveScene(testScene))
            {
                Debug.Log($"In the loop: {timeoutCounter}");
                timeoutCounter++;
                
                if (timeoutCounter == timeoutCounterThreshold)
                    Assert.Fail($"Timeout: loading {testScene.name}");

                yield return new WaitForSeconds(1);
            }
            
            Assert.Pass($"{scene} is loaded"); 
        }
        else
        {
            Assert.Fail($"{scene} does not exist. Existing scene is {SceneManager.GetActiveScene().name}");
        }
        
        
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
