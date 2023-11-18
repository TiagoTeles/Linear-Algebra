module lapack
    use,intrinsic :: iso_c_binding
    implicit none

    contains

    subroutine sgesv_dotnet(n, nrhs, a, lda, ipiv, b, ldb, info) bind(c, name='sgesv_dotnet')
        implicit none
        external :: sgesv

        integer(c_int), intent(in)    :: n
        integer(c_int), intent(in)    :: nrhs
        real(c_float),  intent(inout) :: a(lda, n)
        integer(c_int), intent(in)    :: lda
        integer(c_int), intent(out)   :: ipiv(n)
        real(c_float),  intent(inout) :: b(ldb, nrhs)
        integer(c_int), intent(in)    :: ldb
        integer(c_int), intent(out)   :: info

        call sgesv(n, nrhs, a, lda, ipiv, b, ldb, info)

    end subroutine sgesv_dotnet

end module lapack