﻿using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using MediatR;
using Moq;
using PaySky.Core.ContributorAggregate;
using PaySky.Core.Services;
using PaySky.SharedKernel.Interfaces;
using Xunit;

namespace PaySky.UnitTests.Core.Services;
public class DeleteContributorService_DeleteContributor
{
  private readonly Mock<IRepository<Contributor>> _mockRepo = new Mock<IRepository<Contributor>>();
  private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
  private readonly DeleteContributorService _service;

  public DeleteContributorService_DeleteContributor()
  {
    _service = new DeleteContributorService(_mockRepo.Object, _mockMediator.Object);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenCantFindContributor()
  {
    var result = await _service.DeleteContributor(0);

    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
  }
}
