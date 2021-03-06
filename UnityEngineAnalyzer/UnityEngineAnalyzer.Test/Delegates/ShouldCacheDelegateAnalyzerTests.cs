using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Text;
using NUnit.Framework;
using RoslynNUnitLight;
using UnityEngineAnalyzer.Delegates;


//using Microsoft.CodeAnalysis.Workspaces;

namespace UnityEngineAnalyzer.Test.Delegates
{
    [TestFixture]
    sealed class ShouldCacheDelegatesAnalyzerTests : AnalyzerTestFixture
    {

        protected override string LanguageName => LanguageNames.CSharp;
        protected override DiagnosticAnalyzer CreateAnalyzer() => new ShouldCacheDelegateAnalyzer();

        [Test]
        public void DidNotCacheDelegate()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public EventHandler e;
    void Update()
    {
        e += [|OnCallBack|];
    }

    private void OnCallBack(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                HasDiagnostic(document, span, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }


        [Test]
        public void DidNotCacheDelegateInAwake()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public EventHandler e;
    void Awake()
    {
        e += [|OnCallBack|];
    }

    private void OnCallBack(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                NoDiagnostic(document, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }

        [Test]
        public void DidNotCacheDelegate2()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public EventHandler e;
    void Update()
    {
        e += this.[|OnCallBack|];
    }

    private void OnCallBack(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                HasDiagnostic(document, span, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }


        [Test]
        public void DidNotCacheDelegate2InAwake()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public EventHandler e;
    void Awake()
    {
        e += this.[|OnCallBack|];
    }

    private void OnCallBack(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                NoDiagnostic(document, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }

        [Test]
        public void EventDidNotCacheDelegate()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public event EventHandler e;
    void Update()
    {
        e += [|OnCallBack|];
    }

    private void OnCallBack(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                HasDiagnostic(document, span, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }


        [Test]
        public void EventDidNotCacheDelegateInAwake()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public event EventHandler e;
    void Awake()
    {
        e += [|OnCallBack|];
    }

    private void OnCallBack(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                NoDiagnostic(document, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }

        [Test]
        public void EventDidNotCacheDelegate2()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public event EventHandler e;
    void Update()
    {
        e -= [|OnCallBack|];
    }

    private void OnCallBack(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                HasDiagnostic(document, span, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }


        [Test]
        public void EventDidNotCacheDelegate2InAwake()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public event EventHandler e;
    void Awake()
    {
        e -= [|OnCallBack|];
    }

    private void OnCallBack(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                NoDiagnostic(document, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }

        [Test]
        public void EventDidCacheDelegate()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public event EventHandler e;
    private EventHandler m_cachedDelegate = OnCallBack;

    void Intialize()
    {
        m_cachedDelegate = OnCallBack;
    }

    void Update()
    {
        e += [|m_cachedDelegate|];
    }

    private void OnCallBack(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                NoDiagnostic(document, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }



        [Test]
        public void FunctionDidNotCacheDelegate()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public event EventHandler e;
    void Update()
    {
        CallDelegate([|OnCallBack|]);
    }

    private void CallDelegate(EventHandler handler)
    {
        
    }    

    private void OnCallBack(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                HasDiagnostic(document, span, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }


        [Test]
        public void FunctionDidNotCacheDelegateInAwake()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public event EventHandler e;
    void Awake()
    {
        CallDelegate([|OnCallBack|]);
    }

    private void CallDelegate(EventHandler handler)
    {
        
    }    

    private void OnCallBack(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                NoDiagnostic(document, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }

        [Test]
        public void FunctionDidCacheDelegate()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public event EventHandler e;
    private EventHandler m_cachedDelegate;

    void Intialize()
    {
        m_cachedDelegate = OnCallBack;
    }

    void Update()
    {
        CallDelegate([|m_cachedDelegate|]);
    }

    private void CallDelegate(EventHandler handler)
    {
        
    }    

    private void OnCallBack(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                NoDiagnostic(document, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }


        [Test]
        public void FunctionIsNotDelegate()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public event EventHandler e;
    void Update()
    {
        Call([|ReturnInt()|]);
    }

    private void Call(int intValue)
    {
        
    }    

    private int ReturnInt()
    {
        return 0;
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                NoDiagnostic(document, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }


        [Test]
        public void FunctionIsNotDelegateInAwake()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public event EventHandler e;
    void Awake()
    {
        Call([|ReturnInt()|]);
    }

    private void Call(int intValue)
    {
        
    }    

    private int ReturnInt()
    {
        return 0;
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                NoDiagnostic(document, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }



        [Test]
        public void FunctionIsNotDelegate2()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public event EventHandler e;
    void Update()
    {
        Call(this.[|ReturnInt()|]);
    }

    private void Call(int intValue)
    {
        
    }    

    private int ReturnInt()
    {
        return 0;
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                NoDiagnostic(document, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }

        [Test]
        public void FunctionIsNotDelegate3()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public string s;
    private EventHandler m_cachedDelegate = OnCallBack;

    void Intialize()
    {
        m_cachedDelegate = OnCallBack;
    }

    void Update()
    {
        s += [|ToString()|];
    }

    private void OnCallBack(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                NoDiagnostic(document, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }



        [Test]
        public void FunctionIsNotDelegateAndDidNotCacheDelegate()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public event EventHandler e;
    void Update()
    {
        Call(ReturnInt(), [|OnCallBack|]);
    }

    private void Call(int intValue, EventHandler h)
    {
        
    }    

    private int ReturnInt()
    {
        return 0;
    }

    private void OnCallBack(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                HasDiagnostic(document, span, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }



        [Test]
        public void FunctionIsNotDelegateAndDidNotCacheDelegateInAwake()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public event EventHandler e;
    void Awake()
    {
        Call(ReturnInt(), [|OnCallBack|]);
    }

    private void Call(int intValue, EventHandler h)
    {
        
    }    

    private int ReturnInt()
    {
        return 0;
    }

    private void OnCallBack(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                NoDiagnostic(document, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }

        [Test]
        public void FunctionIsNotDelegateAndDidNotCacheDelegate_IgnoreStaticMethod()
        {
            var code = @"

using System;
using UnityEngine;

class C : MonoBehaviour
{
    public event EventHandler e;
    void Update()
    {
        Call(ReturnInt(), [|OnCallBack|]);
    }

    private void Call(int intValue, EventHandler h)
    {
        
    }    

    private int ReturnInt()
    {
        return 0;
    }

    private static void OnCallBack(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}";

            Document document;
            TextSpan span;

            if (TestHelpers.TryGetDocumentAndSpanFromMarkup(code, LanguageName, MetadataReferenceHelper.UsingUnityEngine,
                out document, out span))
            {
                NoDiagnostic(document, DiagnosticIDs.ShouldCacheDelegate);
            }
            else
            {
                Assert.Fail("Could not load unit test code");
            }
        }
    }
}
