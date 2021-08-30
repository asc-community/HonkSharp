## .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```assembly
; Benchmark.RangeForeachBenchmark.LoopFor()
;             var a = 0;
;             ^^^^^^^^^^
       xor       eax,eax
       mov       edx,[rcx+8]
       mov       ecx,[rcx+0C]
;             for (int i = 0; i < n; i += Inc)
;                  ^^^^^^^^^
       xor       r8d,r8d
       test      edx,edx
       jle       short M00_L01
;                 a += i;
;                 ^^^^^^^
M00_L00:
       add       eax,r8d
       add       r8d,ecx
       cmp       r8d,edx
       jl        short M00_L00
M00_L01:
       ret
; Total bytes of code 27
```

## .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```assembly
; Benchmark.RangeForeachBenchmark.LoopForeachEnumerable()
       push      rbp
       push      rsi
       sub       rsp,38
       lea       rbp,[rsp+40]
       mov       [rbp+0FFE0],rsp
;             var a = 0;
;             ^^^^^^^^^^
       xor       esi,esi
       mov       edx,[rcx+8]
       xor       ecx,ecx
       call      System.Linq.Enumerable.Range(Int32, Int32)
       mov       rcx,rax
       mov       r11,7FF9B11803A0
       call      qword ptr [7FF9B14E03A0]
       mov       rcx,rax
       mov       [rbp+0FFF0],rcx
;             foreach (var i in Enumerable.Range(0, n))
;                            ^^
       mov       r11,7FF9B11803A8
       call      qword ptr [7FF9B14E03A8]
       test      eax,eax
       je        short M00_L01
M00_L00:
       mov       rcx,[rbp+0FFF0]
       mov       r11,7FF9B11803B0
       call      qword ptr [7FF9B14E03B0]
;                 a += i;
;                 ^^^^^^^
       add       esi,eax
       mov       rcx,[rbp+0FFF0]
       mov       r11,7FF9B11803A8
       call      qword ptr [7FF9B14E03A8]
       test      eax,eax
       jne       short M00_L00
M00_L01:
       mov       rcx,[rbp+0FFF0]
       mov       r11,7FF9B11803B8
       call      qword ptr [7FF9B14E03B8]
;             return a;
;             ^^^^^^^^^
       mov       eax,esi
       lea       rsp,[rbp+0FFF8]
       pop       rsi
       pop       rbp
       ret
       push      rbp
       push      rsi
       sub       rsp,28
       mov       rbp,[rcx+20]
       mov       [rsp+20],rbp
       lea       rbp,[rbp+40]
       cmp       qword ptr [rbp+0FFF0],0
       je        short M00_L02
       mov       rcx,[rbp+0FFF0]
       mov       r11,7FF9B11803B8
       call      qword ptr [7FF9B14E03B8]
M00_L02:
       nop
       add       rsp,28
       pop       rsi
       pop       rbp
       ret
; Total bytes of code 202
```
```assembly
; System.Linq.Enumerable.Range(Int32, Int32)
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       edi,ecx
       mov       esi,edx
       movsxd    rcx,edi
       movsxd    rax,esi
       lea       rcx,[rcx+rax+0FFFF]
       test      esi,esi
       jl        short M01_L00
       cmp       rcx,7FFFFFFF
       jg        short M01_L00
       test      esi,esi
       je        short M01_L01
       mov       rcx,offset MT_System.Linq.Enumerable+RangeIterator
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      CORINFO_HELP_GETCURRENTMANAGEDTHREADID
       mov       [rbx+8],eax
       mov       [rbx+14],edi
       add       esi,edi
       mov       [rbx+18],esi
       mov       rax,rbx
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M01_L00:
       mov       ecx,1
       call      System.Linq.ThrowHelper.ThrowArgumentOutOfRangeException(System.Linq.ExceptionArgument)
       int       3
M01_L01:
       mov       rcx,7FF9B13DF638
       mov       edx,2
       call      CORINFO_HELP_CLASSINIT_SHARED_DYNAMICCLASS
       mov       rax,28936B02EE8
       mov       rax,[rax]
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 136
```

## .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```assembly
; Benchmark.RangeForeachBenchmark.LoopForeachHonkRange()
       push      rsi
       sub       rsp,40
       xor       eax,eax
       mov       [rsp+30],rax
       mov       [rsp+38],rax
;             var a = 0;
;             ^^^^^^^^^^
       xor       esi,esi
       mov       edx,[rcx+8]
;             foreach (var i in 0..(n - 1))
;                               ^^^^^^^^^^
       dec       edx
       test      edx,edx
       jl        short M00_L02
       mov       [rsp+28],esi
       mov       [rsp+2C],edx
       mov       rdx,[rsp+28]
       lea       rcx,[rsp+30]
       call      HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
       mov       eax,[rsp+38]
       add       eax,[rsp+34]
       mov       [rsp+38],eax
       mov       eax,[rsp+38]
       cmp       eax,[rsp+30]
       je        short M00_L01
       nop       dword ptr [rax]
M00_L00:
       mov       eax,[rsp+38]
;                 a += i;
;                 ^^^^^^^
       add       esi,eax
       mov       eax,[rsp+38]
       add       eax,[rsp+34]
       mov       [rsp+38],eax
       mov       eax,[rsp+38]
       cmp       eax,[rsp+30]
       jne       short M00_L00
;             return a;
;             ^^^^^^^^^
M00_L01:
       mov       eax,esi
       add       rsp,40
       pop       rsi
       ret
M00_L02:
       call      System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()
       int       3
; Total bytes of code 122
```
```assembly
; HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
       push      rsi
       sub       rsp,20
       mov       [rsp+38],rdx
       mov       eax,[rsp+38]
       mov       edx,[rsp+3C]
       test      eax,eax
       jge       short M01_L01
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       test      edx,edx
       jge       short M01_L00
       mov       eax,edx
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       mov       eax,80000000
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L00:
       jmp       short M01_L03
M01_L01:
       test      edx,edx
       jge       short M01_L02
       mov       r8d,edx
       not       r8d
       mov       r9d,r8d
       test      r9d,r9d
       jne       short M01_L07
       dec       eax
       mov       r9d,eax
       mov       eax,80000000
       mov       r8d,1
       jmp       short M01_L06
M01_L02:
       jmp       short M01_L04
M01_L03:
       add       edx,2
       mov       eax,edx
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L04:
       mov       r9d,eax
       mov       eax,edx
       cmp       r9d,eax
       jge       short M01_L05
       inc       eax
       dec       r9d
       mov       r8d,1
       jmp       short M01_L06
M01_L05:
       dec       eax
       inc       r9d
       mov       r8d,0FFFFFFFF
M01_L06:
       mov       [rcx],eax
       mov       [rcx+4],r8d
       mov       [rcx+8],r9d
       mov       rax,rcx
       add       rsp,20
       pop       rsi
       ret
M01_L07:
       mov       rcx,offset MT_System.InvalidOperationException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       ecx,91
       mov       rdx,7FF9B15B3E18
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       rcx,rsi
       call      System.InvalidOperationException..ctor(System.String)
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 237
```
**Method was not JITted yet.**
System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()

## .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```assembly
; Benchmark.RangeForeachBenchmark.LoopForeachHonkRangeRaw()
       push      rsi
       sub       rsp,40
       xor       eax,eax
       mov       [rsp+30],rax
       mov       [rsp+38],rax
;             var a = 0;
;             ^^^^^^^^^^
       xor       esi,esi
       mov       edx,[rcx+8]
;             var enumerator = (0..(n - 1)).GetEnumerator();
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
       dec       edx
       test      edx,edx
       jl        short M00_L02
       mov       [rsp+28],esi
       mov       [rsp+2C],edx
       mov       rdx,[rsp+28]
       lea       rcx,[rsp+30]
       call      HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
;             while (enumerator.MoveNext())
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
       mov       eax,[rsp+38]
       add       eax,[rsp+34]
       mov       [rsp+38],eax
       mov       eax,[rsp+38]
       cmp       eax,[rsp+30]
       je        short M00_L01
       nop       dword ptr [rax]
M00_L00:
       add       esi,[rsp+38]
       mov       eax,[rsp+38]
       add       eax,[rsp+34]
       mov       [rsp+38],eax
       mov       eax,[rsp+38]
       cmp       eax,[rsp+30]
       jne       short M00_L00
;             return a;
;             ^^^^^^^^^
M00_L01:
       mov       eax,esi
       add       rsp,40
       pop       rsi
       ret
M00_L02:
       call      System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()
       int       3
; Total bytes of code 120
```
```assembly
; HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
       push      rsi
       sub       rsp,20
       mov       [rsp+38],rdx
       mov       eax,[rsp+38]
       mov       edx,[rsp+3C]
       test      eax,eax
       jge       short M01_L01
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       test      edx,edx
       jge       short M01_L00
       mov       eax,edx
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       mov       eax,80000000
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L00:
       jmp       short M01_L03
M01_L01:
       test      edx,edx
       jge       short M01_L02
       mov       r8d,edx
       not       r8d
       mov       r9d,r8d
       test      r9d,r9d
       jne       short M01_L07
       dec       eax
       mov       r9d,eax
       mov       eax,80000000
       mov       r8d,1
       jmp       short M01_L06
M01_L02:
       jmp       short M01_L04
M01_L03:
       add       edx,2
       mov       eax,edx
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L04:
       mov       r9d,eax
       mov       eax,edx
       cmp       r9d,eax
       jge       short M01_L05
       inc       eax
       dec       r9d
       mov       r8d,1
       jmp       short M01_L06
M01_L05:
       dec       eax
       inc       r9d
       mov       r8d,0FFFFFFFF
M01_L06:
       mov       [rcx],eax
       mov       [rcx+4],r8d
       mov       [rcx+8],r9d
       mov       rax,rcx
       add       rsp,20
       pop       rsi
       ret
M01_L07:
       mov       rcx,offset MT_System.InvalidOperationException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       ecx,91
       mov       rdx,7FF9B15B23D8
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       rcx,rsi
       call      System.InvalidOperationException..ctor(System.String)
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 237
```
**Method was not JITted yet.**
System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()

## .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```assembly
; Benchmark.RangeForeachBenchmark.LoopForeachHonkRangeRawWithEnumeratorHidden()
;             var n = N;
;             ^^^^^^^^^^
;             var enumerator = (0..(n - 1)).GetEnumerator();
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
;             return GoOverThing(enumerator);
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
       sub       rsp,48
       xor       eax,eax
       mov       [rsp+38],rax
       mov       [rsp+40],rax
       mov       edx,[rcx+8]
       dec       edx
       test      edx,edx
       jl        short M00_L00
       xor       ecx,ecx
       mov       [rsp+30],ecx
       mov       [rsp+34],edx
       mov       rdx,[rsp+30]
       lea       rcx,[rsp+38]
       call      HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
       mov       rcx,[rsp+38]
       mov       [rsp+20],rcx
       mov       ecx,[rsp+40]
       mov       [rsp+28],ecx
       lea       rcx,[rsp+20]
       call      Benchmark.RangeForeachBenchmark.<LoopForeachHonkRangeRawWithEnumeratorHidden>g__GoOverThing|12_0(RangeEnumerator)
       nop
       add       rsp,48
       ret
M00_L00:
       call      System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()
       int       3
; Total bytes of code 90
```
```assembly
; HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
       push      rsi
       sub       rsp,20
       mov       [rsp+38],rdx
       mov       eax,[rsp+38]
       mov       edx,[rsp+3C]
       test      eax,eax
       jge       short M01_L01
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       test      edx,edx
       jge       short M01_L00
       mov       eax,edx
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       mov       eax,80000000
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L00:
       jmp       short M01_L03
M01_L01:
       test      edx,edx
       jge       short M01_L02
       mov       r8d,edx
       not       r8d
       mov       r9d,r8d
       test      r9d,r9d
       jne       short M01_L07
       dec       eax
       mov       r9d,eax
       mov       eax,80000000
       mov       r8d,1
       jmp       short M01_L06
M01_L02:
       jmp       short M01_L04
M01_L03:
       add       edx,2
       mov       eax,edx
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L04:
       mov       r9d,eax
       mov       eax,edx
       cmp       r9d,eax
       jge       short M01_L05
       inc       eax
       dec       r9d
       mov       r8d,1
       jmp       short M01_L06
M01_L05:
       dec       eax
       inc       r9d
       mov       r8d,0FFFFFFFF
M01_L06:
       mov       [rcx],eax
       mov       [rcx+4],r8d
       mov       [rcx+8],r9d
       mov       rax,rcx
       add       rsp,20
       pop       rsi
       ret
M01_L07:
       mov       rcx,offset MT_System.InvalidOperationException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       ecx,91
       mov       rdx,7FF9B1593E18
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       rcx,rsi
       call      System.InvalidOperationException..ctor(System.String)
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 237
```
```assembly
; Benchmark.RangeForeachBenchmark.<LoopForeachHonkRangeRawWithEnumeratorHidden>g__GoOverThing|12_0(RangeEnumerator)
       mov       eax,[rcx]
       mov       edx,[rcx+4]
       mov       ecx,[rcx+8]
;                 var a = 0;
;                 ^^^^^^^^^^
       xor       r8d,r8d
;                 while (enumerator.MoveNext())
;                 ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
       add       ecx,edx
       cmp       ecx,eax
       je        short M02_L01
M02_L00:
       add       r8d,ecx
       add       ecx,edx
       cmp       ecx,eax
       jne       short M02_L00
;                 return a;
;                 ^^^^^^^^^
M02_L01:
       mov       eax,r8d
       ret
; Total bytes of code 30
```
**Method was not JITted yet.**
System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()

## .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```assembly
; Benchmark.RangeForeachBenchmark.LoopFor()
;             var a = 0;
;             ^^^^^^^^^^
       xor       eax,eax
       mov       edx,[rcx+8]
       mov       ecx,[rcx+0C]
;             for (int i = 0; i < n; i += Inc)
;                  ^^^^^^^^^
       xor       r8d,r8d
       test      edx,edx
       jle       short M00_L01
;                 a += i;
;                 ^^^^^^^
M00_L00:
       add       eax,r8d
       add       r8d,ecx
       cmp       r8d,edx
       jl        short M00_L00
M00_L01:
       ret
; Total bytes of code 27
```

## .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```assembly
; Benchmark.RangeForeachBenchmark.LoopForeachEnumerable()
       push      rbp
       push      rsi
       sub       rsp,38
       lea       rbp,[rsp+40]
       mov       [rbp+0FFE0],rsp
;             var a = 0;
;             ^^^^^^^^^^
       xor       esi,esi
       mov       edx,[rcx+8]
       xor       ecx,ecx
       call      System.Linq.Enumerable.Range(Int32, Int32)
       mov       rcx,rax
       mov       r11,7FF9B11B03A0
       call      qword ptr [7FF9B15103A0]
       mov       rcx,rax
       mov       [rbp+0FFF0],rcx
;             foreach (var i in Enumerable.Range(0, n))
;                            ^^
       mov       r11,7FF9B11B03A8
       call      qword ptr [7FF9B15103A8]
       test      eax,eax
       je        short M00_L01
M00_L00:
       mov       rcx,[rbp+0FFF0]
       mov       r11,7FF9B11B03B0
       call      qword ptr [7FF9B15103B0]
;                 a += i;
;                 ^^^^^^^
       add       esi,eax
       mov       rcx,[rbp+0FFF0]
       mov       r11,7FF9B11B03A8
       call      qword ptr [7FF9B15103A8]
       test      eax,eax
       jne       short M00_L00
M00_L01:
       mov       rcx,[rbp+0FFF0]
       mov       r11,7FF9B11B03B8
       call      qword ptr [7FF9B15103B8]
;             return a;
;             ^^^^^^^^^
       mov       eax,esi
       lea       rsp,[rbp+0FFF8]
       pop       rsi
       pop       rbp
       ret
       push      rbp
       push      rsi
       sub       rsp,28
       mov       rbp,[rcx+20]
       mov       [rsp+20],rbp
       lea       rbp,[rbp+40]
       cmp       qword ptr [rbp+0FFF0],0
       je        short M00_L02
       mov       rcx,[rbp+0FFF0]
       mov       r11,7FF9B11B03B8
       call      qword ptr [7FF9B15103B8]
M00_L02:
       nop
       add       rsp,28
       pop       rsi
       pop       rbp
       ret
; Total bytes of code 202
```
```assembly
; System.Linq.Enumerable.Range(Int32, Int32)
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       edi,ecx
       mov       esi,edx
       movsxd    rcx,edi
       movsxd    rax,esi
       lea       rcx,[rcx+rax+0FFFF]
       test      esi,esi
       jl        short M01_L00
       cmp       rcx,7FFFFFFF
       jg        short M01_L00
       test      esi,esi
       je        short M01_L01
       mov       rcx,offset MT_System.Linq.Enumerable+RangeIterator
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      CORINFO_HELP_GETCURRENTMANAGEDTHREADID
       mov       [rbx+8],eax
       mov       [rbx+14],edi
       add       esi,edi
       mov       [rbx+18],esi
       mov       rax,rbx
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M01_L00:
       mov       ecx,1
       call      System.Linq.ThrowHelper.ThrowArgumentOutOfRangeException(System.Linq.ExceptionArgument)
       int       3
M01_L01:
       mov       rcx,7FF9B1450A50
       mov       edx,2
       call      CORINFO_HELP_CLASSINIT_SHARED_DYNAMICCLASS
       mov       rax,1A475F82EE8
       mov       rax,[rax]
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 136
```

## .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```assembly
; Benchmark.RangeForeachBenchmark.LoopForeachHonkRange()
       push      rsi
       sub       rsp,40
       xor       eax,eax
       mov       [rsp+30],rax
       mov       [rsp+38],rax
;             var a = 0;
;             ^^^^^^^^^^
       xor       esi,esi
       mov       edx,[rcx+8]
;             foreach (var i in 0..(n - 1))
;                               ^^^^^^^^^^
       dec       edx
       test      edx,edx
       jl        short M00_L02
       mov       [rsp+28],esi
       mov       [rsp+2C],edx
       mov       rdx,[rsp+28]
       lea       rcx,[rsp+30]
       call      HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
       mov       eax,[rsp+38]
       add       eax,[rsp+34]
       mov       [rsp+38],eax
       mov       eax,[rsp+38]
       cmp       eax,[rsp+30]
       je        short M00_L01
       nop       dword ptr [rax]
M00_L00:
       mov       eax,[rsp+38]
;                 a += i;
;                 ^^^^^^^
       add       esi,eax
       mov       eax,[rsp+38]
       add       eax,[rsp+34]
       mov       [rsp+38],eax
       mov       eax,[rsp+38]
       cmp       eax,[rsp+30]
       jne       short M00_L00
;             return a;
;             ^^^^^^^^^
M00_L01:
       mov       eax,esi
       add       rsp,40
       pop       rsi
       ret
M00_L02:
       call      System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()
       int       3
; Total bytes of code 122
```
```assembly
; HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
       push      rsi
       sub       rsp,20
       mov       [rsp+38],rdx
       mov       eax,[rsp+38]
       mov       edx,[rsp+3C]
       test      eax,eax
       jge       short M01_L01
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       test      edx,edx
       jge       short M01_L00
       mov       eax,edx
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       mov       eax,80000000
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L00:
       jmp       short M01_L03
M01_L01:
       test      edx,edx
       jge       short M01_L02
       mov       r8d,edx
       not       r8d
       mov       r9d,r8d
       test      r9d,r9d
       jne       short M01_L07
       dec       eax
       mov       r9d,eax
       mov       eax,80000000
       mov       r8d,1
       jmp       short M01_L06
M01_L02:
       jmp       short M01_L04
M01_L03:
       add       edx,2
       mov       eax,edx
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L04:
       mov       r9d,eax
       mov       eax,edx
       cmp       r9d,eax
       jge       short M01_L05
       inc       eax
       dec       r9d
       mov       r8d,1
       jmp       short M01_L06
M01_L05:
       dec       eax
       inc       r9d
       mov       r8d,0FFFFFFFF
M01_L06:
       mov       [rcx],eax
       mov       [rcx+4],r8d
       mov       [rcx+8],r9d
       mov       rax,rcx
       add       rsp,20
       pop       rsi
       ret
M01_L07:
       mov       rcx,offset MT_System.InvalidOperationException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       ecx,91
       mov       rdx,7FF9B15C3590
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       rcx,rsi
       call      System.InvalidOperationException..ctor(System.String)
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 237
```
**Method was not JITted yet.**
System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()

## .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```assembly
; Benchmark.RangeForeachBenchmark.LoopForeachHonkRangeRaw()
       push      rsi
       sub       rsp,40
       xor       eax,eax
       mov       [rsp+30],rax
       mov       [rsp+38],rax
;             var a = 0;
;             ^^^^^^^^^^
       xor       esi,esi
       mov       edx,[rcx+8]
;             var enumerator = (0..(n - 1)).GetEnumerator();
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
       dec       edx
       test      edx,edx
       jl        short M00_L02
       mov       [rsp+28],esi
       mov       [rsp+2C],edx
       mov       rdx,[rsp+28]
       lea       rcx,[rsp+30]
       call      HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
;             while (enumerator.MoveNext())
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
       mov       eax,[rsp+38]
       add       eax,[rsp+34]
       mov       [rsp+38],eax
       mov       eax,[rsp+38]
       cmp       eax,[rsp+30]
       je        short M00_L01
       nop       dword ptr [rax]
M00_L00:
       add       esi,[rsp+38]
       mov       eax,[rsp+38]
       add       eax,[rsp+34]
       mov       [rsp+38],eax
       mov       eax,[rsp+38]
       cmp       eax,[rsp+30]
       jne       short M00_L00
;             return a;
;             ^^^^^^^^^
M00_L01:
       mov       eax,esi
       add       rsp,40
       pop       rsi
       ret
M00_L02:
       call      System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()
       int       3
; Total bytes of code 120
```
```assembly
; HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
       push      rsi
       sub       rsp,20
       mov       [rsp+38],rdx
       mov       eax,[rsp+38]
       mov       edx,[rsp+3C]
       test      eax,eax
       jge       short M01_L01
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       test      edx,edx
       jge       short M01_L00
       mov       eax,edx
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       mov       eax,80000000
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L00:
       jmp       short M01_L03
M01_L01:
       test      edx,edx
       jge       short M01_L02
       mov       r8d,edx
       not       r8d
       mov       r9d,r8d
       test      r9d,r9d
       jne       short M01_L07
       dec       eax
       mov       r9d,eax
       mov       eax,80000000
       mov       r8d,1
       jmp       short M01_L06
M01_L02:
       jmp       short M01_L04
M01_L03:
       add       edx,2
       mov       eax,edx
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L04:
       mov       r9d,eax
       mov       eax,edx
       cmp       r9d,eax
       jge       short M01_L05
       inc       eax
       dec       r9d
       mov       r8d,1
       jmp       short M01_L06
M01_L05:
       dec       eax
       inc       r9d
       mov       r8d,0FFFFFFFF
M01_L06:
       mov       [rcx],eax
       mov       [rcx+4],r8d
       mov       [rcx+8],r9d
       mov       rax,rcx
       add       rsp,20
       pop       rsi
       ret
M01_L07:
       mov       rcx,offset MT_System.InvalidOperationException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       ecx,91
       mov       rdx,7FF9B15945D8
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       rcx,rsi
       call      System.InvalidOperationException..ctor(System.String)
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 237
```
**Method was not JITted yet.**
System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()

## .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```assembly
; Benchmark.RangeForeachBenchmark.LoopForeachHonkRangeRawWithEnumeratorHidden()
;             var n = N;
;             ^^^^^^^^^^
;             var enumerator = (0..(n - 1)).GetEnumerator();
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
;             return GoOverThing(enumerator);
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
       sub       rsp,48
       xor       eax,eax
       mov       [rsp+38],rax
       mov       [rsp+40],rax
       mov       edx,[rcx+8]
       dec       edx
       test      edx,edx
       jl        short M00_L00
       xor       ecx,ecx
       mov       [rsp+30],ecx
       mov       [rsp+34],edx
       mov       rdx,[rsp+30]
       lea       rcx,[rsp+38]
       call      HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
       mov       rcx,[rsp+38]
       mov       [rsp+20],rcx
       mov       ecx,[rsp+40]
       mov       [rsp+28],ecx
       lea       rcx,[rsp+20]
       call      Benchmark.RangeForeachBenchmark.<LoopForeachHonkRangeRawWithEnumeratorHidden>g__GoOverThing|12_0(RangeEnumerator)
       nop
       add       rsp,48
       ret
M00_L00:
       call      System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()
       int       3
; Total bytes of code 90
```
```assembly
; HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
       push      rsi
       sub       rsp,20
       mov       [rsp+38],rdx
       mov       eax,[rsp+38]
       mov       edx,[rsp+3C]
       test      eax,eax
       jge       short M01_L01
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       test      edx,edx
       jge       short M01_L00
       mov       eax,edx
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       mov       eax,80000000
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L00:
       jmp       short M01_L03
M01_L01:
       test      edx,edx
       jge       short M01_L02
       mov       r8d,edx
       not       r8d
       mov       r9d,r8d
       test      r9d,r9d
       jne       short M01_L07
       dec       eax
       mov       r9d,eax
       mov       eax,80000000
       mov       r8d,1
       jmp       short M01_L06
M01_L02:
       jmp       short M01_L04
M01_L03:
       add       edx,2
       mov       eax,edx
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L04:
       mov       r9d,eax
       mov       eax,edx
       cmp       r9d,eax
       jge       short M01_L05
       inc       eax
       dec       r9d
       mov       r8d,1
       jmp       short M01_L06
M01_L05:
       dec       eax
       inc       r9d
       mov       r8d,0FFFFFFFF
M01_L06:
       mov       [rcx],eax
       mov       [rcx+4],r8d
       mov       [rcx+8],r9d
       mov       rax,rcx
       add       rsp,20
       pop       rsi
       ret
M01_L07:
       mov       rcx,offset MT_System.InvalidOperationException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       ecx,91
       mov       rdx,7FF9B15B3E18
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       rcx,rsi
       call      System.InvalidOperationException..ctor(System.String)
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 237
```
```assembly
; Benchmark.RangeForeachBenchmark.<LoopForeachHonkRangeRawWithEnumeratorHidden>g__GoOverThing|12_0(RangeEnumerator)
       mov       eax,[rcx]
       mov       edx,[rcx+4]
       mov       ecx,[rcx+8]
;                 var a = 0;
;                 ^^^^^^^^^^
       xor       r8d,r8d
;                 while (enumerator.MoveNext())
;                 ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
       add       ecx,edx
       cmp       ecx,eax
       je        short M02_L01
M02_L00:
       add       r8d,ecx
       add       ecx,edx
       cmp       ecx,eax
       jne       short M02_L00
;                 return a;
;                 ^^^^^^^^^
M02_L01:
       mov       eax,r8d
       ret
; Total bytes of code 30
```
**Method was not JITted yet.**
System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()

## .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```assembly
; Benchmark.RangeForeachBenchmark.LoopFor()
;             var a = 0;
;             ^^^^^^^^^^
       xor       eax,eax
       mov       edx,[rcx+8]
       mov       ecx,[rcx+0C]
;             for (int i = 0; i < n; i += Inc)
;                  ^^^^^^^^^
       xor       r8d,r8d
       test      edx,edx
       jle       short M00_L01
;                 a += i;
;                 ^^^^^^^
M00_L00:
       add       eax,r8d
       add       r8d,ecx
       cmp       r8d,edx
       jl        short M00_L00
M00_L01:
       ret
; Total bytes of code 27
```

## .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```assembly
; Benchmark.RangeForeachBenchmark.LoopForeachEnumerable()
       push      rbp
       push      rsi
       sub       rsp,38
       lea       rbp,[rsp+40]
       mov       [rbp+0FFE0],rsp
;             var a = 0;
;             ^^^^^^^^^^
       xor       esi,esi
       mov       edx,[rcx+8]
       xor       ecx,ecx
       call      System.Linq.Enumerable.Range(Int32, Int32)
       mov       rcx,rax
       mov       r11,7FF9B1190390
       call      qword ptr [7FF9B14F0390]
       mov       rcx,rax
       mov       [rbp+0FFF0],rcx
;             foreach (var i in Enumerable.Range(0, n))
;                            ^^
       mov       r11,7FF9B1190398
       call      qword ptr [7FF9B14F0398]
       test      eax,eax
       je        short M00_L01
M00_L00:
       mov       rcx,[rbp+0FFF0]
       mov       r11,7FF9B11903A0
       call      qword ptr [7FF9B14F03A0]
;                 a += i;
;                 ^^^^^^^
       add       esi,eax
       mov       rcx,[rbp+0FFF0]
       mov       r11,7FF9B1190398
       call      qword ptr [7FF9B14F0398]
       test      eax,eax
       jne       short M00_L00
M00_L01:
       mov       rcx,[rbp+0FFF0]
       mov       r11,7FF9B11903A8
       call      qword ptr [7FF9B14F03A8]
;             return a;
;             ^^^^^^^^^
       mov       eax,esi
       lea       rsp,[rbp+0FFF8]
       pop       rsi
       pop       rbp
       ret
       push      rbp
       push      rsi
       sub       rsp,28
       mov       rbp,[rcx+20]
       mov       [rsp+20],rbp
       lea       rbp,[rbp+40]
       cmp       qword ptr [rbp+0FFF0],0
       je        short M00_L02
       mov       rcx,[rbp+0FFF0]
       mov       r11,7FF9B11903A8
       call      qword ptr [7FF9B14F03A8]
M00_L02:
       nop
       add       rsp,28
       pop       rsi
       pop       rbp
       ret
; Total bytes of code 202
```
```assembly
; System.Linq.Enumerable.Range(Int32, Int32)
       push      rdi
       push      rsi
       push      rbx
       sub       rsp,20
       mov       edi,ecx
       mov       esi,edx
       movsxd    rcx,edi
       movsxd    rax,esi
       lea       rcx,[rcx+rax+0FFFF]
       test      esi,esi
       jl        short M01_L00
       cmp       rcx,7FFFFFFF
       jg        short M01_L00
       test      esi,esi
       je        short M01_L01
       mov       rcx,offset MT_System.Linq.Enumerable+RangeIterator
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       call      CORINFO_HELP_GETCURRENTMANAGEDTHREADID
       mov       [rbx+8],eax
       mov       [rbx+14],edi
       add       esi,edi
       mov       [rbx+18],esi
       mov       rax,rbx
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
M01_L00:
       mov       ecx,1
       call      System.Linq.ThrowHelper.ThrowArgumentOutOfRangeException(System.Linq.ExceptionArgument)
       int       3
M01_L01:
       mov       rcx,7FF9B13EF638
       mov       edx,2
       call      CORINFO_HELP_CLASSINIT_SHARED_DYNAMICCLASS
       mov       rax,1FDF5E62EE8
       mov       rax,[rax]
       add       rsp,20
       pop       rbx
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 136
```

## .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```assembly
; Benchmark.RangeForeachBenchmark.LoopForeachHonkRange()
       push      rsi
       sub       rsp,40
       xor       eax,eax
       mov       [rsp+30],rax
       mov       [rsp+38],rax
;             var a = 0;
;             ^^^^^^^^^^
       xor       esi,esi
       mov       edx,[rcx+8]
;             foreach (var i in 0..(n - 1))
;                               ^^^^^^^^^^
       dec       edx
       test      edx,edx
       jl        short M00_L02
       mov       [rsp+28],esi
       mov       [rsp+2C],edx
       mov       rdx,[rsp+28]
       lea       rcx,[rsp+30]
       call      HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
       mov       eax,[rsp+38]
       add       eax,[rsp+34]
       mov       [rsp+38],eax
       mov       eax,[rsp+38]
       cmp       eax,[rsp+30]
       je        short M00_L01
       nop       dword ptr [rax]
M00_L00:
       mov       eax,[rsp+38]
;                 a += i;
;                 ^^^^^^^
       add       esi,eax
       mov       eax,[rsp+38]
       add       eax,[rsp+34]
       mov       [rsp+38],eax
       mov       eax,[rsp+38]
       cmp       eax,[rsp+30]
       jne       short M00_L00
;             return a;
;             ^^^^^^^^^
M00_L01:
       mov       eax,esi
       add       rsp,40
       pop       rsi
       ret
M00_L02:
       call      System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()
       int       3
; Total bytes of code 122
```
```assembly
; HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
       push      rsi
       sub       rsp,20
       mov       [rsp+38],rdx
       mov       eax,[rsp+38]
       mov       edx,[rsp+3C]
       test      eax,eax
       jge       short M01_L01
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       test      edx,edx
       jge       short M01_L00
       mov       eax,edx
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       mov       eax,80000000
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L00:
       jmp       short M01_L03
M01_L01:
       test      edx,edx
       jge       short M01_L02
       mov       r8d,edx
       not       r8d
       mov       r9d,r8d
       test      r9d,r9d
       jne       short M01_L07
       dec       eax
       mov       r9d,eax
       mov       eax,80000000
       mov       r8d,1
       jmp       short M01_L06
M01_L02:
       jmp       short M01_L04
M01_L03:
       add       edx,2
       mov       eax,edx
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L04:
       mov       r9d,eax
       mov       eax,edx
       cmp       r9d,eax
       jge       short M01_L05
       inc       eax
       dec       r9d
       mov       r8d,1
       jmp       short M01_L06
M01_L05:
       dec       eax
       inc       r9d
       mov       r8d,0FFFFFFFF
M01_L06:
       mov       [rcx],eax
       mov       [rcx+4],r8d
       mov       [rcx+8],r9d
       mov       rax,rcx
       add       rsp,20
       pop       rsi
       ret
M01_L07:
       mov       rcx,offset MT_System.InvalidOperationException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       ecx,91
       mov       rdx,7FF9B15B39C0
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       rcx,rsi
       call      System.InvalidOperationException..ctor(System.String)
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 237
```
**Method was not JITted yet.**
System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()

## .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```assembly
; Benchmark.RangeForeachBenchmark.LoopForeachHonkRangeRaw()
       push      rsi
       sub       rsp,40
       xor       eax,eax
       mov       [rsp+30],rax
       mov       [rsp+38],rax
;             var a = 0;
;             ^^^^^^^^^^
       xor       esi,esi
       mov       edx,[rcx+8]
;             var enumerator = (0..(n - 1)).GetEnumerator();
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
       dec       edx
       test      edx,edx
       jl        short M00_L02
       mov       [rsp+28],esi
       mov       [rsp+2C],edx
       mov       rdx,[rsp+28]
       lea       rcx,[rsp+30]
       call      HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
;             while (enumerator.MoveNext())
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
       mov       eax,[rsp+38]
       add       eax,[rsp+34]
       mov       [rsp+38],eax
       mov       eax,[rsp+38]
       cmp       eax,[rsp+30]
       je        short M00_L01
       nop       dword ptr [rax]
M00_L00:
       add       esi,[rsp+38]
       mov       eax,[rsp+38]
       add       eax,[rsp+34]
       mov       [rsp+38],eax
       mov       eax,[rsp+38]
       cmp       eax,[rsp+30]
       jne       short M00_L00
;             return a;
;             ^^^^^^^^^
M00_L01:
       mov       eax,esi
       add       rsp,40
       pop       rsi
       ret
M00_L02:
       call      System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()
       int       3
; Total bytes of code 120
```
```assembly
; HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
       push      rsi
       sub       rsp,20
       mov       [rsp+38],rdx
       mov       eax,[rsp+38]
       mov       edx,[rsp+3C]
       test      eax,eax
       jge       short M01_L01
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       test      edx,edx
       jge       short M01_L00
       mov       eax,edx
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       mov       eax,80000000
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L00:
       jmp       short M01_L03
M01_L01:
       test      edx,edx
       jge       short M01_L02
       mov       r8d,edx
       not       r8d
       mov       r9d,r8d
       test      r9d,r9d
       jne       short M01_L07
       dec       eax
       mov       r9d,eax
       mov       eax,80000000
       mov       r8d,1
       jmp       short M01_L06
M01_L02:
       jmp       short M01_L04
M01_L03:
       add       edx,2
       mov       eax,edx
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L04:
       mov       r9d,eax
       mov       eax,edx
       cmp       r9d,eax
       jge       short M01_L05
       inc       eax
       dec       r9d
       mov       r8d,1
       jmp       short M01_L06
M01_L05:
       dec       eax
       inc       r9d
       mov       r8d,0FFFFFFFF
M01_L06:
       mov       [rcx],eax
       mov       [rcx+4],r8d
       mov       [rcx+8],r9d
       mov       rax,rcx
       add       rsp,20
       pop       rsi
       ret
M01_L07:
       mov       rcx,offset MT_System.InvalidOperationException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       ecx,91
       mov       rdx,7FF9B1593E18
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       rcx,rsi
       call      System.InvalidOperationException..ctor(System.String)
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 237
```
**Method was not JITted yet.**
System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()

## .NET 6.0.0 (6.0.21.35212), X64 RyuJIT
```assembly
; Benchmark.RangeForeachBenchmark.LoopForeachHonkRangeRawWithEnumeratorHidden()
;             var n = N;
;             ^^^^^^^^^^
;             var enumerator = (0..(n - 1)).GetEnumerator();
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
;             return GoOverThing(enumerator);
;             ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
       sub       rsp,48
       xor       eax,eax
       mov       [rsp+38],rax
       mov       [rsp+40],rax
       mov       edx,[rcx+8]
       dec       edx
       test      edx,edx
       jl        short M00_L00
       xor       ecx,ecx
       mov       [rsp+30],ecx
       mov       [rsp+34],edx
       mov       rdx,[rsp+30]
       lea       rcx,[rsp+38]
       call      HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
       mov       rcx,[rsp+38]
       mov       [rsp+20],rcx
       mov       ecx,[rsp+40]
       mov       [rsp+28],ecx
       lea       rcx,[rsp+20]
       call      Benchmark.RangeForeachBenchmark.<LoopForeachHonkRangeRawWithEnumeratorHidden>g__GoOverThing|12_0(RangeEnumerator)
       nop
       add       rsp,48
       ret
M00_L00:
       call      System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()
       int       3
; Total bytes of code 90
```
```assembly
; HonkSharp.Fluency.SeqsExtensions.GetEnumerator(System.Range)
       push      rsi
       sub       rsp,20
       mov       [rsp+38],rdx
       mov       eax,[rsp+38]
       mov       edx,[rsp+3C]
       test      eax,eax
       jge       short M01_L01
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       test      edx,edx
       jge       short M01_L00
       mov       eax,edx
       not       eax
       test      eax,eax
       jne       near ptr M01_L07
       mov       eax,80000000
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L00:
       jmp       short M01_L03
M01_L01:
       test      edx,edx
       jge       short M01_L02
       mov       r8d,edx
       not       r8d
       mov       r9d,r8d
       test      r9d,r9d
       jne       short M01_L07
       dec       eax
       mov       r9d,eax
       mov       eax,80000000
       mov       r8d,1
       jmp       short M01_L06
M01_L02:
       jmp       short M01_L04
M01_L03:
       add       edx,2
       mov       eax,edx
       mov       r8d,1
       mov       r9d,0FFFFFFFF
       jmp       short M01_L06
M01_L04:
       mov       r9d,eax
       mov       eax,edx
       cmp       r9d,eax
       jge       short M01_L05
       inc       eax
       dec       r9d
       mov       r8d,1
       jmp       short M01_L06
M01_L05:
       dec       eax
       inc       r9d
       mov       r8d,0FFFFFFFF
M01_L06:
       mov       [rcx],eax
       mov       [rcx+4],r8d
       mov       [rcx+8],r9d
       mov       rax,rcx
       add       rsp,20
       pop       rsi
       ret
M01_L07:
       mov       rcx,offset MT_System.InvalidOperationException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       ecx,91
       mov       rdx,7FF9B15C3E18
       call      CORINFO_HELP_STRCNS
       mov       rdx,rax
       mov       rcx,rsi
       call      System.InvalidOperationException..ctor(System.String)
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 237
```
```assembly
; Benchmark.RangeForeachBenchmark.<LoopForeachHonkRangeRawWithEnumeratorHidden>g__GoOverThing|12_0(RangeEnumerator)
       mov       eax,[rcx]
       mov       edx,[rcx+4]
       mov       ecx,[rcx+8]
;                 var a = 0;
;                 ^^^^^^^^^^
       xor       r8d,r8d
;                 while (enumerator.MoveNext())
;                 ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
       add       ecx,edx
       cmp       ecx,eax
       je        short M02_L01
M02_L00:
       add       r8d,ecx
       add       ecx,edx
       cmp       ecx,eax
       jne       short M02_L00
;                 return a;
;                 ^^^^^^^^^
M02_L01:
       mov       eax,r8d
       ret
; Total bytes of code 30
```
**Method was not JITted yet.**
System.ThrowHelper.ThrowValueArgumentOutOfRange_NeedNonNegNumException()

