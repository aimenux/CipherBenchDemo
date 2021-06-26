# CipherBenchDemo
```
Benchmarking implementation ways of encryption/decryption with AES cipher
```

In this demo, i m using [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) library in order to benchmark various implementation of AES cipher :
>
> :one: Using [microsoft library](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography)
>
> :two: Using [BouncyCastle library](https://github.com/bcgit/bc-csharp)
>

In order to run benchmarks, type these commands in your favorite terminal :
>
> :writing_hand: `.\App.exe --filter EncryptionBench`
>
> :writing_hand: `.\App.exe --filter DecryptionBench`
>

```
|            Method | Length |     Mean |     Error |    StdDev |       Min |      Max | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |------- |---------:|----------:|----------:|----------:|---------:|-----:|-------:|------:|------:|----------:|
| EncryptWithLibTwo |     16 | 1.022 μs | 0.0162 μs | 0.0135 μs | 0.9966 μs | 1.041 μs |    1 | 0.1106 |     - |     - |     464 B |
| EncryptWithLibOne |     16 | 1.416 μs | 0.0278 μs | 0.0399 μs | 1.3603 μs | 1.493 μs |    2 | 0.1812 |     - |     - |     760 B |
|                   |        |          |           |           |           |          |      |        |       |       |           |
| EncryptWithLibTwo |     32 | 1.496 μs | 0.0275 μs | 0.0338 μs | 1.4544 μs | 1.580 μs |    1 | 0.1564 |     - |     - |     656 B |
| EncryptWithLibOne |     32 | 1.663 μs | 0.0247 μs | 0.0219 μs | 1.6173 μs | 1.694 μs |    2 | 0.2270 |     - |     - |     952 B |
|                   |        |          |           |           |           |          |      |        |       |       |           |
| EncryptWithLibOne |     64 | 2.311 μs | 0.0448 μs | 0.0419 μs | 2.2435 μs | 2.385 μs |    1 | 0.3166 |     - |     - |   1,336 B |
| EncryptWithLibTwo |     64 | 2.400 μs | 0.0469 μs | 0.0482 μs | 2.3325 μs | 2.504 μs |    2 | 0.2480 |     - |     - |   1,040 B |
|                   |        |          |           |           |           |          |      |        |       |       |           |
| EncryptWithLibOne |    128 | 3.644 μs | 0.0719 μs | 0.0910 μs | 3.5400 μs | 3.869 μs |    1 | 0.4997 |     - |     - |   2,104 B |
| EncryptWithLibTwo |    128 | 4.255 μs | 0.0647 μs | 0.0573 μs | 4.1257 μs | 4.322 μs |    2 | 0.4272 |     - |     - |   1,808 B |
|                   |        |          |           |           |           |          |      |        |       |       |           |
| EncryptWithLibOne |    256 | 5.906 μs | 0.0756 μs | 0.0707 μs | 5.7522 μs | 6.001 μs |    1 | 0.8698 |     - |     - |   3,640 B |
| EncryptWithLibTwo |    256 | 8.040 μs | 0.1423 μs | 0.1331 μs | 7.8380 μs | 8.296 μs |    2 | 0.7935 |     - |     - |   3,344 B |
```

**`Tools`** : vs19, net 5.0